namespace Trn.Foundation.Customization.Extensions
{
    using Newtonsoft.Json;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using Sitecore.LayoutService.Serialization;
    using Sitecore.LayoutService.Serialization.FieldSerializers;
    using Sitecore.LayoutService.Serialization.ItemSerializers;
    using Sitecore.LayoutService.Serialization.Pipelines.GetFieldSerializer;
    using Sitecore.Links;
    using System;
    using System.Collections.Generic;



    /// <summary>
    /// CustomFieldSerializer class that inherits from <inheritdoc cref="BaseFieldSerializer"/>
    /// </summary>
    public class CustomFieldSerializer : BaseFieldSerializer
    {
        protected readonly IItemSerializer ItemSerializer;
        public CustomFieldSerializer(IItemSerializer itemSerializer, IFieldRenderer fieldRenderer)
          : base(fieldRenderer)
        {
            Assert.ArgumentNotNull((object)itemSerializer, nameof(itemSerializer));
            this.ItemSerializer = itemSerializer;
        }

        public override void Serialize(Field field, JsonTextWriter writer)
        {

            Assert.ArgumentNotNull((object)field, nameof(field));
            Assert.ArgumentNotNull((object)writer, nameof(writer));
            try
            {
                using (RecursionLimit recursionLimit = new RecursionLimit(string.Format("{0}|{1}|{2}", (object)this.GetType().FullName, (object)field.Item.ID, (object)field.ID), 1))
                {
                    if (recursionLimit.Exceeded)
                        this.HandleRecursionLimitExceeded(field, writer);
                    else
                        this.WriteField(field, writer);
                }
            }
            catch (Exception exception)
            {
                Sitecore.Diagnostics.Log.Error("CustomFieldSerializer Serialize method Exception::  " + exception.Message, exception, this);
            }
        }

        protected virtual void WriteValueObject(Item item, InternalLinkField field, JsonTextWriter writer)
        {
            Assert.IsNotNull((object)item, nameof(item));
            this.WriteProperties(this.GetProperties(item, field), field, writer);
        }


        protected virtual void WriteProperties(IEnumerable<InternalLinkFieldSerializer.Property> properties, InternalLinkField field, JsonTextWriter writer)
        {
            try
            {
                ((JsonWriter)writer).WriteStartObject();
                foreach (InternalLinkFieldSerializer.Property property in properties)
                {
                    ((JsonWriter)writer).WritePropertyName(property.Key);
                    if (property.IsValueJson)
                    {
                        this.WriteCustomFieldProperties(field, writer);
                        //((JsonWriter)writer).WriteRawValue(property.Value);
                    }
                    else
                        ((JsonWriter)writer).WriteValue(property.Value);
                }
                ((JsonWriter)writer).WriteEndObject();
            }
            catch (Exception exception)
            {
                Sitecore.Diagnostics.Log.Error("CustomFieldSerializer WriteProperties method Exception::  " + exception.Message, exception, this);
            }
        }

        protected virtual IEnumerable<InternalLinkFieldSerializer.Property> GetProperties(Item item, InternalLinkField field)
        {
            return (IEnumerable<InternalLinkFieldSerializer.Property>)new List<InternalLinkFieldSerializer.Property>()
              {
                new InternalLinkFieldSerializer.Property("id", item.ID.Guid.ToString()),
                new InternalLinkFieldSerializer.Property("name", item.Name),
                new InternalLinkFieldSerializer.Property("url", this.GetLinkUrl(item, field)),
                new InternalLinkFieldSerializer.Property("fields", this.GetSerializedTargetItem(item, field), true)
              };
        }

        protected virtual string GetLinkUrl(Item item, InternalLinkField field) => LinkManager.GetItemUrl(item, this.UrlOptions);
        protected virtual string GetSerializedTargetItem(Item item, InternalLinkField field) => this.ItemSerializer.Serialize(item);
        protected virtual void HandleRecursionLimitExceeded(Field field, JsonTextWriter writer) { }
        protected virtual void WriteField(Field field, JsonTextWriter writer)
        {
            ((JsonWriter)writer).WritePropertyName(field.Name);
            this.WriteValue(field, writer);
        }

        protected override void WriteValue(Field field, JsonTextWriter writer)
        {
            InternalLinkField field1 = new InternalLinkField(field);
            Item targetItem = field1?.TargetItem;
            if (targetItem == null)
                this.WriteEmptyValue(field1, writer);
            else
                this.WriteValueObject(targetItem, field1, writer);
        }

        protected virtual void WriteEmptyValue(InternalLinkField field, JsonTextWriter writer) => ((JsonWriter)writer).WriteNull();

        protected virtual void WriteCustomFieldProperties(InternalLinkField field, JsonTextWriter writer)
        {
            Field domainField = null;
            Field urlLinkField = null;
            Field errorListField = null;

            try
            {
                Item ApiUrlItem = Sitecore.Context.Database.Items.GetItem(field?.Value);
                if (ApiUrlItem != null)
                {
                    domainField = ApiUrlItem?.Fields["Domain"];
                    urlLinkField = ApiUrlItem?.Fields["UrlLink"];
                    errorListField = ApiUrlItem?.Fields["ErrorList"];

                    writer.WriteStartObject();

                    writer.WritePropertyName(domainField?.Name);
                    writer.WriteValue(domainField?.Value);
                    if (urlLinkField != null)
                    {
                        if (!string.IsNullOrEmpty(urlLinkField.Value) && !urlLinkField.Value.Contains("http"))
                        {
                            writer.WritePropertyName(urlLinkField.Name);
                            string baseApiURLSetting = Sitecore.Configuration.Settings.GetSetting(domainField?.Value);
                            writer.WriteValue(baseApiURLSetting + urlLinkField.Value);
                        }
                        else
                        {
                            writer.WritePropertyName(urlLinkField.Name);
                            writer.WriteValue(urlLinkField.Value);
                        }
                    }
                    writer.WritePropertyName(errorListField.Name);
                    writer.WriteValue(errorListField.Value);

                    writer.WriteEndObject();
                }
            }
            catch (Exception exception)
            {
                Sitecore.Diagnostics.Log.Error("CustomFieldSerializer WriteCustomFieldProperties method Exception::  " + exception.Message, exception, this);
            }
            finally
            {
                if (domainField != null)
                    ((IDisposable)domainField).Dispose();
                if (urlLinkField != null)
                    ((IDisposable)urlLinkField).Dispose();
                if (errorListField != null)
                    ((IDisposable)errorListField).Dispose();
            }
        }
        public class Property
        {
            public Property(string name, string value, bool isValueJson = false)
            {
                this.Key = name;
                this.Value = value;
                this.IsValueJson = isValueJson;
            }

            public string Key { get; set; }

            public string Value { get; set; }

            public bool IsValueJson { get; set; }
        }
    }

    public class GetCustomFieldSerializer : BaseGetFieldSerializer
    {
        public GetCustomFieldSerializer(IFieldRenderer fieldRenderer)
            : base(fieldRenderer)
        {
        }


        protected override void SetResult(GetFieldSerializerPipelineArgs args)
        {
            Assert.ArgumentNotNull((object)args, nameof(args));
            args.Result = new CustomFieldSerializer(args.ItemSerializer, this.FieldRenderer);
        }
    }
}