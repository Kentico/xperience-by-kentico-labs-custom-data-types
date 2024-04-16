import { FormComponentProps } from "@kentico/xperience-admin-base";
import {
  Input,
  Button,
  ButtonColor,
} from "@kentico/xperience-admin-components";
import React, { ChangeEvent, useState } from "react";
import { AddressDataType, newAddress } from "./AddressDataType";

interface AddressListFormComponentProps extends FormComponentProps {
  newAddress: AddressDataType;
  value: AddressDataType[];
}

export const AddressListFormComponent = (
  props: AddressListFormComponentProps
) => {
  const [addresses, setAddresses] = useState(
    props.value ?? [{ ...props.newAddress }]
  );

  const handleFieldChange = (
    index: number,
    event: ChangeEvent<HTMLInputElement>
  ) => {
    if (props.onChange) {
      const field = event.target.name.replace(
        `${index}-`,
        ""
      ) as keyof AddressDataType;
      const updatedAddress = {
        ...addresses[index],
        [field]: event.target.value,
      };
      const updatedAddresses = addresses.map((a, i) =>
        i === index ? updatedAddress : a
      );
      setAddresses(updatedAddresses);
      props.onChange(updatedAddresses);
    }
  };

  const handleDeleteAddress = (index: number) => {
    if (props.onChange) {
      const updatedAddresses = addresses.filter((a, i) => i !== index);
      setAddresses(updatedAddresses);
      props.onChange(updatedAddresses);
    }
  };

  const handleAddressAdd = () => {
    if (props.onChange) {
      const updatedAddresses = [...addresses, { ...newAddress() }];
      setAddresses(updatedAddresses);
      props.onChange(updatedAddresses);
    }
  };

  const fieldStyle = { marginTop: ".5rem" };

  return (
    <div>
      <label style={{ color: "var(--color-text-default-on-light)" }}>
        {props.label}
      </label>
      {addresses.map((address, index) => (
        <div
          key={address.id}
          style={{
            marginTop: index ? "2rem" : "0",
            color: "var(--color-text-default-on-light)",
          }}
        >
          <div
            style={{
              ...fieldStyle,
              display: "flex",
              flexDirection: "row",
              justifyContent: "space-between",
              alignItems: "center",
            }}
          >
            <label>Address {index + 1}</label>
            <Button
              onClick={() => handleDeleteAddress(index)}
              label="Remove"
              color={ButtonColor.Quinary}
            />
          </div>
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
                name={`${index}-street`}
                value={address.street}
                onChange={(e) => handleFieldChange(index, e)}
              />
            </div>
            <div style={fieldStyle}>
              <Input
                label="City"
                name={`${index}-city`}
                value={address.city}
                onChange={(e) => handleFieldChange(index, e)}
              />
            </div>
            <div style={fieldStyle}>
              <Input
                label="State/Province"
                name={`${index}-stateProvince`}
                value={address.stateProvince}
                onChange={(e) => handleFieldChange(index, e)}
              />
            </div>
            <div style={fieldStyle}>
              <Input
                label="Postal Code"
                name={`${index}-postalCode`}
                value={address.postalCode}
                onChange={(e) => handleFieldChange(index, e)}
              />
            </div>
            <div style={fieldStyle}>
              <Input
                label="Country"
                name={`${index}-country`}
                value={address.country}
                onChange={(e) => handleFieldChange(index, e)}
              />
            </div>
            <div style={fieldStyle}>
              <Input
                label="Phone"
                name={`${index}-phone`}
                value={address.phone}
                onChange={(e) => handleFieldChange(index, e)}
              />
            </div>
          </div>
        </div>
      ))}
      <div style={fieldStyle}>
        <Button
          onClick={handleAddressAdd}
          label="Add Address"
          color={ButtonColor.Primary}
        />
      </div>
    </div>
  );
};
