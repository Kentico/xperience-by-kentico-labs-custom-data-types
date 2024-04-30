import { FormComponentProps } from "@kentico/xperience-admin-base";
import { Input } from "@kentico/xperience-admin-components";
import React, { ChangeEvent, useState } from "react";
import { LinkDataType, LinkDataTypeFields } from "./LinkDataType";

interface LinkDataTypeFormComponentProps extends FormComponentProps {
  newLink: LinkDataType;
  value: LinkDataType;
}

export const LinkDataTypeFormComponent = (
  props: LinkDataTypeFormComponentProps
) => {
  const [link, setLink] = useState(props.value ?? { ...props.newLink });

  const handleFieldChange = (event: ChangeEvent<HTMLInputElement>) => {
    if (props.onChange) {
      const field = event.target.name as keyof LinkDataType;
      const updatedLink = {
        ...link,
        [field]: event.target.value,
      };
      setLink(updatedLink);
      props.onChange(updatedLink);
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
        {LinkDataTypeFields.map((f) => (
          <div style={{ marginTop: ".5rem" }} key={f.value}>
            <Input
              label={f.text}
              name={f.value}
              value={link[f.value]}
              onChange={handleFieldChange}
              disabled={props.disabled}
            />
          </div>
        ))}
      </div>
    </div>
  );
};
