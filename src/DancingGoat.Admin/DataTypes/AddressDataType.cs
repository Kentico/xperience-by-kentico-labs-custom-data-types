using System.Data;

using CMS.DataEngine;
using CMS.DataEngine.Internal;
using CMS.FormEngine;
using CMS.Helpers;

using DancingGoat;

using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

[assembly: RegisterFormComponent(
    AddressListFormComponent.IDENTIFIER,
    typeof(AddressListFormComponent),
    "Address List")]
[assembly: RegisterFormComponent(
    AddressFormComponent.IDENTIFIER,
    typeof(AddressFormComponent),
    "Address")]

namespace DancingGoat;

public static class AddressDataTypeRegister
{
    public static void Register()
    {
        DataTypeManager.RegisterDataTypes(
            new DataType<IEnumerable<AddressDataType>>(
                sqlType: "nvarchar(max)",
                fieldType: AddressDataType.FIELD_TYPE_LIST,
                schemaType: "xs:string",
                conversionFunc: JsonDataTypeConverter.ConvertToModels,
                dbConversionFunc: JsonDataTypeConverter.ConvertToString,
                textSerializer: new DefaultDataTypeTextSerializer(AddressDataType.FIELD_TYPE_LIST))
            {
                TypeAlias = "string",
                TypeGroup = "String",
                SqlValueFormat = DataTypeManager.UNICODE,
                DbType = SqlDbType.NVarChar,
                DefaultValueCode = "[]",
                DefaultValue = [],
                HasConfigurableDefaultValue = false,
            });

        DataTypeManager.RegisterDataTypes(
            new DataType<AddressDataType>(
                sqlType: "nvarchar(max)",
                fieldType: AddressDataType.FIELD_TYPE,
                schemaType: "xs:string",
                conversionFunc: JsonDataTypeConverter.ConvertToModel,
                dbConversionFunc: JsonDataTypeConverter.ConvertToString,
                textSerializer: new DefaultDataTypeTextSerializer(AddressDataType.FIELD_TYPE))
            {
                TypeAlias = "string",
                TypeGroup = "String",
                SqlValueFormat = DataTypeManager.UNICODE,
                DbType = SqlDbType.NVarChar,
                DefaultValueCode = "{ }",
                DefaultValue = new(),
                HasConfigurableDefaultValue = true,
            });

        DataTypeCodeGenerationManager.RegisterDataTypeCodeGenerator(
            AddressDataType.FIELD_TYPE,
            () => new DataTypeCodeGenerator(
                field => "AddressDataType",
                field => nameof(ValidationHelper.GetString),
                field => "new()",
                field => ["DancingGoat"]));

        DataTypeCodeGenerationManager.RegisterDataTypeCodeGenerator(
            AddressDataType.FIELD_TYPE_LIST,
            () => new DataTypeCodeGenerator(
                field => "IEnumerable<AddressDataType>",
                field => nameof(ValidationHelper.GetString),
                field => "[]",
                field => ["System.Collections.Generic", "DancingGoat"]));
    }
}

public class AddressDataType
{
    public const string FIELD_TYPE = "address";
    public const string FIELD_TYPE_LIST = "addresslist";

    public Guid ID { get; set; } = Guid.NewGuid();
    public string Street { get; set; } = "";
    public string City { get; set; } = "";
    public string StateProvince { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string Country { get; set; } = "";
    public string Phone { get; set; } = "";
}

public class AddressListFormComponentAttribute : FormComponentAttribute { }

[ComponentAttribute(typeof(AddressListFormComponentAttribute))]
public class AddressListFormComponent : FormComponent<
    AddressListFormComponentProperties,
    AddressListFormComponentClientProperties,
    IEnumerable<AddressDataType>>
{
    public const string IDENTIFIER = "DancingGoat.FormComponent.AddressList";

    public override string ClientComponentName => "@acme/web-admin/AddressListDataType";
}

public class AddressListFormComponentProperties : FormComponentProperties { }

public class AddressListFormComponentClientProperties : FormComponentClientProperties<IEnumerable<AddressDataType>>
{
    public AddressDataType NewAddress { get; } = new AddressDataType();
}

public class AddressFormComponentAttribute : FormComponentAttribute { }

[ComponentAttribute(typeof(AddressFormComponentAttribute))]
public class AddressFormComponent : FormComponent<
    AddressFormComponentProperties,
    AddressFormComponentClientProperties,
    AddressDataType>
{
    public const string IDENTIFIER = "DancingGoat.FormComponent.Address";

    public override string ClientComponentName => "@acme/web-admin/AddressDataType";
}

public class AddressFormComponentProperties : FormComponentProperties { }

public class AddressFormComponentClientProperties : FormComponentClientProperties<AddressDataType>
{
    public AddressDataType NewAddress { get; } = new AddressDataType();
}

