using System.Globalization;

using CMS.Core;
using CMS.DataEngine.Internal;

using DancingGoat.Admin;

using Kentico.Xperience.Admin.Base;

[assembly: CMS.AssemblyDiscoverable]
[assembly: CMS.RegisterModule(typeof(AcmeWebAdminModule))]

// Adds a new application category 
[assembly: UICategory(AcmeWebAdminModule.CUSTOM_CATEGORY, "Custom", Icons.CustomElement, 100)]

namespace DancingGoat.Admin
{
    internal class AcmeWebAdminModule : AdminModule
    {
        public const string CUSTOM_CATEGORY = "acme.web.admin.category";

        public AcmeWebAdminModule()
            : base("Acme.Web.Admin")
        {
        }

        protected override void OnPreInit(ModulePreInitParameters parameters)
        {
            base.OnPreInit(parameters);

            AddressDataTypeRegister.Register();
            LinkDataTypeRegister.Register();

            RegisterDefaultValueComponent(LinkDataType.FIELD_TYPE,
                LinkFormComponent.IDENTIFIER,
                (val) => val is LinkDataType link ? JsonDataTypeConverter.ConvertToString(link, new(), CultureInfo.CurrentCulture).ToString() ?? "" : "",
                (val) => JsonDataTypeConverter.ConvertToModel<LinkDataType>(val, new(), CultureInfo.CurrentCulture));
        }

        protected override void OnInit()
        {
            base.OnInit();

            // Makes the module accessible to the admin UI
            RegisterClientModule("acme", "web-admin");
        }
    }
}
