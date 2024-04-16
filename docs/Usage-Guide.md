# Usage Guide

The `DancingGoat.Admin` .NET project contains all the custom data types, their registration and UI form components used to edit the
data types.

Key files:

- `CustomDataTypeModule.cs` - contains the data type registration calls
- `DataTypes/LinkDataType.cs,LinkDataType.cs` - custom data type class definitions, type registration, code generation registration, and UI Form Components
- `Client/src` - contains the client type definitions and React form components
- `DancingGoatAdminResources.resx,.cs` - localized values for auto-generated resource strings used by custom data types (used in administration UI)

Currently, the `Cafe` content type uses the `Address` custom data type and `Coffee` content type uses the `LinkList` custom data type.

You can see the marketer content management experience by editing content items of these types in the Content hub.

Follow the guidance in `~/src/DancingGoat/README.md` to re-generate any content type C# classes if you modify the content type definitions and want
to see how the custom data type code generation works.
