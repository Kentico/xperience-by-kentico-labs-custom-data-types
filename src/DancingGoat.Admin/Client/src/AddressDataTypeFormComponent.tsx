import { FormComponentProps } from "@kentico/xperience-admin-base";
import {
  Input,
  Button,
  ButtonColor,
} from "@kentico/xperience-admin-components";
import React, { ChangeEvent, useState } from "react";
import { AddressDataType } from "./AddressDataType";

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

  const fieldStyle = { marginTop: ".5rem" };

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
        <div style={fieldStyle}>
          <Input
            label="Street"
            name={`street`}
            value={address.street}
            onChange={handleFieldChange}
          />
        </div>
        <div style={fieldStyle}>
          <Input
            label="City"
            name={`city`}
            value={address.city}
            onChange={handleFieldChange}
          />
        </div>
        <div style={fieldStyle}>
          <Input
            label="State/Province"
            name={`stateProvince`}
            value={address.stateProvince}
            onChange={handleFieldChange}
          />
        </div>
        <div style={fieldStyle}>
          <Input
            label="Postal Code"
            name={`postalCode`}
            value={address.postalCode}
            onChange={handleFieldChange}
          />
        </div>
        <div style={fieldStyle}>
          <Input
            label="Country"
            name={`country`}
            value={address.country}
            onChange={handleFieldChange}
          />
        </div>
        <div style={fieldStyle}>
          <Input
            label="Phone"
            name={`phone`}
            value={address.phone}
            onChange={handleFieldChange}
          />
        </div>
      </div>
    </div>
  );
};
