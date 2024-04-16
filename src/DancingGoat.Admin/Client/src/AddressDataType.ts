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
