export type LinkDataType = {
  id: string;
  label: string;
  url: string;
};

export function newLink(): LinkDataType {
  return {
    id: crypto.randomUUID(),
    label: "",
    url: "",
  };
}

export type LinkDataTypeField = Exclude<keyof LinkDataType, "id">;

export const LinkDataTypeFields: {
  value: LinkDataTypeField;
  text: string;
}[] = [
  {
    value: "label",
    text: "Label",
  },
  {
    value: "url",
    text: "URL",
  },
];
