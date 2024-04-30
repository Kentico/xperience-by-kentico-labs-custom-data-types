export type AddressDataType = {
  id: string;
  street: string;
  city: string;
  stateProvince: string;
  postalCode: string;
  country: string;
  phone: string;
};

export function newAddress(): AddressDataType {
  return {
    id: crypto.randomUUID(),
    street: "",
    city: "",
    stateProvince: "",
    postalCode: "",
    country: "",
    phone: "",
  };
}

export type AddressDataTypeField = Exclude<keyof AddressDataType, "id">;

export const AddressDataTypeFields: {
  value: AddressDataTypeField;
  text: string;
}[] = [
  {
    value: "street",
    text: "Street",
  },
  {
    value: "city",
    text: "City",
  },
  {
    value: "stateProvince",
    text: "State or Province",
  },
  {
    value: "postalCode",
    text: "Postal Code",
  },
  {
    value: "country",
    text: "Country",
  },
  {
    value: "phone",
    text: "Phone",
  },
];
