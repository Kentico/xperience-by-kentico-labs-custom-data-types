import { FormComponentProps } from "@kentico/xperience-admin-base";
import {
  Input,
  Button,
  ButtonColor,
} from "@kentico/xperience-admin-components";
import React, { ChangeEvent, useState } from "react";
import {
  AddressDataType,
  newAddress,
  AddressDataTypeFields,
} from "./AddressDataType";

interface AddressDataTypeListFormComponentProps extends FormComponentProps {
  newAddress: AddressDataType;
  value: AddressDataType[];
}

export const AddressListDataTypeFormComponent = (
  props: AddressDataTypeListFormComponentProps
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
              marginTop: ".5rem",
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
            {AddressDataTypeFields.map((f) => (
              <div style={{ marginTop: ".5rem" }} key={f.value}>
                <Input
                  label={f.text}
                  name={`${index}-${f.value}`}
                  value={address[f.value]}
                  onChange={(e) => handleFieldChange(index, e)}
                  disabled={props.disabled}
                />
              </div>
            ))}
          </div>
        </div>
      ))}
      <div style={{ marginTop: ".5rem" }}>
        <Button
          onClick={handleAddressAdd}
          label="Add Address"
          color={ButtonColor.Primary}
        />
      </div>
    </div>
  );
};
