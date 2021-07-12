import React from 'react';
import { Text } from '@sitecore-jss/sitecore-jss-react';

const Trnheader = (props) => (
  <div>
    <p>Trnheader Component</p>
    <Text field={props.fields.heading} />
  </div>
);

export default Trnheader;
