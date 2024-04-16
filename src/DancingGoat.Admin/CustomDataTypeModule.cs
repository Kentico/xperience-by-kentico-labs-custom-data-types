using CMS;
using CMS.Core;
using CMS.DataEngine;

using DancingGoat;

[assembly: RegisterModule(typeof(CustomDataTypeModule))]

namespace DancingGoat;

public class CustomDataTypeModule : Module
{
    public CustomDataTypeModule() : base(nameof(CustomDataTypeModule))
    {
    }

    protected override void OnPreInit(ModulePreInitParameters parameters)
    {
        base.OnPreInit(parameters);

        AddressDataTypeRegister.Register();
        LinkDataTypeRegister.Register();
    }
}
