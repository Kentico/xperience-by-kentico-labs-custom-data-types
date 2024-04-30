import { FormComponentProps } from "@kentico/xperience-admin-base";
import {
  Input,
  Button,
  ButtonColor,
} from "@kentico/xperience-admin-components";
import React, { ChangeEvent, useState } from "react";
import { AddressDataType, AddressDataTypeFields } from "./AddressDataType";

interface AddressDataTypeFormComponentProps extends FormComponentProps {
  newAddress: AddressDataType;
  value: AddressDataType;
}

export const AddressDataTypeFormComponent = (
  props: AddressDataTypeFormComponentProps
) => {
  const [address, setAddress] = useState(
    props.value ?? { ...props.newAddress }
  );

  const handleFieldChange = (event: ChangeEvent<HTMLInputElement>) => {
    if (props.onChange) {
      const field = event.target.name as keyof AddressDataType;
      const updatedAddress = {
        ...address,
        [field]: event.target.value,
      };
      setAddress(updatedAddress);
      props.onChange(updatedAddress);
    }
  };

  return (
    <div>
      <label style={{ color: "var(--color-text-default-on-light)" }}>
        {props.label}
      </label>
      <div
        style={{
          display: "grid",
          gridTemplateColumns: "1fr 1fr",
          gap: "1rem",
        }}
      >
        {AddressDataTypeFields.map((f) => (
          <div style={{ marginTop: ".5rem" }} key={f.value}>
            <Input
              label={f.text}
              name={f.value}
              value={address[f.value]}
              onChange={handleFieldChange}
            />
          </div>
        ))}
      </div>
    </div>
  );
};
