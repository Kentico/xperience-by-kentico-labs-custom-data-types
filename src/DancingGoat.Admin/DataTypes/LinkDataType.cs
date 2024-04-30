using System.Data;

using CMS.DataEngine;
using CMS.DataEngine.Internal;
using CMS.FormEngine;
using CMS.Helpers;

using DancingGoat;

using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

[assembly: RegisterFormComponent(
    LinkListFormComponent.IDENTIFIER,
    typeof(LinkListFormComponent),
    "Link List")]
[assembly: RegisterFormComponent(
    LinkFormComponent.IDENTIFIER,
    typeof(LinkFormComponent),
    "Link")]

namespace DancingGoat;

public static class LinkDataTypeRegister
{
    public static void Register()
    {
        DataTypeManager.RegisterDataTypes(
            new DataType<IEnumerable<LinkDataType>>(
                sqlType: "nvarchar(max)",
                fieldType: LinkDataType.FIELD_TYPE_LIST,
                schemaType: "xs:string",
                conversionFunc: JsonDataTypeConverter.ConvertToModels,
                dbConversionFunc: JsonDataTypeConverter.ConvertToString,
                textSerializer: new DefaultDataTypeTextSerializer(LinkDataType.FIELD_TYPE_LIST))
            {
                TypeAlias = "string",
                TypeGroup = "String",
                SqlValueFormat = DataTypeManager.UNICODE,
                DbType = SqlDbType.NVarChar,
                DefaultValueCode = "[]",
                DefaultValue = [],
                HasConfigurableDefaultValue = true,
            },
            new DataType<LinkDataType>(
                sqlType: "nvarchar(max)",
                fieldType: LinkDataType.FIELD_TYPE,
                schemaType: "xs:string",
                conversionFunc: JsonDataTypeConverter.ConvertToModel,
                dbConversionFunc: JsonDataTypeConverter.ConvertToString,
                textSerializer: new DefaultDataTypeTextSerializer(LinkDataType.FIELD_TYPE))
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
            LinkDataType.FIELD_TYPE,
            () => new DataTypeCodeGenerator(
                field => "LinkDataType",
                field => nameof(ValidationHelper.GetString),
                field => "new()",
                field => ["DancingGoat"]));

        DataTypeCodeGenerationManager.RegisterDataTypeCodeGenerator(
            LinkDataType.FIELD_TYPE_LIST,
            () => new DataTypeCodeGenerator(
                field => "IEnumerable<LinkDataType>",
                field => nameof(ValidationHelper.GetString),
                field => "[]",
                field => ["System.Collections.Generic", "DancingGoat"]));
    }
}


public class LinkDataType
{
    public const string FIELD_TYPE = "link";
    public const string FIELD_TYPE_LIST = "linklist";

    public Guid ID { get; set; } = Guid.NewGuid();
    public string Label { get; set; } = "";
    public string URL { get; set; } = "";
}

public class LinkListFormComponentAttribute : FormComponentAttribute { }

[ComponentAttribute(typeof(LinkListFormComponentAttribute))]
public class LinkListFormComponent : FormComponent<
    LinkListFormComponentProperties,
    LinkListFormComponentClientProperties,
    IEnumerable<LinkDataType>>
{
    public const string IDENTIFIER = "DancingGoat.FormComponent.LinkList";

    public override string ClientComponentName => "@acme/web-admin/LinkListDataType";
}

public class LinkListFormComponentProperties : FormComponentProperties { }

public class LinkListFormComponentClientProperties : FormComponentClientProperties<IEnumerable<LinkDataType>>
{
    public LinkDataType NewLink { get; } = new LinkDataType();
}


public class LinkFormComponentAttribute : FormComponentAttribute { }

[ComponentAttribute(typeof(LinkFormComponentAttribute))]
public class LinkFormComponent : FormComponent<
    LinkFormComponentProperties,
    LinkFormComponentClientProperties,
    LinkDataType>
{
    public const string IDENTIFIER = "DancingGoat.FormComponent.Link";

    public override string ClientComponentName => "@acme/web-admin/LinkDataType";
}

public class LinkFormComponentProperties : FormComponentProperties { }

public class LinkFormComponentClientProperties : FormComponentClientProperties<LinkDataType>
{
    public LinkDataType NewLink { get; } = new LinkDataType();
}
