﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace CDataBinding
{
    public partial class App : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
    private global::CDataBinding.CDataBinding_XamlTypeInfo.XamlTypeInfoProvider _provider;

        /// <summary>
        /// GetXamlType(Type)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            if(_provider == null)
            {
                _provider = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByType(type);
        }

        /// <summary>
        /// GetXamlType(String)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            if(_provider == null)
            {
                _provider = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByName(fullName);
        }

        /// <summary>
        /// GetXmlnsDefinitions()
        /// </summary>
        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return new global::Windows.UI.Xaml.Markup.XmlnsDefinition[0];
        }
    }
}

namespace CDataBinding.CDataBinding_XamlTypeInfo
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal partial class XamlTypeInfoProvider
    {
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByType(global::System.Type type)
        {
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByType.TryGetValue(type, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByType(type);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByName(typeName);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlMember GetMemberByLongName(string longMemberName)
        {
            if (string.IsNullOrEmpty(longMemberName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlMember xamlMember;
            if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
            {
                return xamlMember;
            }
            xamlMember = CreateXamlMember(longMemberName);
            if (xamlMember != null)
            {
                _xamlMembers.Add(longMemberName, xamlMember);
            }
            return xamlMember;
        }

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByName = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByType = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>
                _xamlMembers = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>();

        string[] _typeNameTable = null;
        global::System.Type[] _typeTable = null;

        private void InitTypeTables()
        {
            _typeNameTable = new string[12];
            _typeNameTable[0] = "CDataBinding.MainPage";
            _typeNameTable[1] = "Windows.UI.Xaml.Controls.Page";
            _typeNameTable[2] = "Windows.UI.Xaml.Controls.UserControl";
            _typeNameTable[3] = "System.Collections.ObjectModel.ObservableCollection`1<CDataBinding.Set>";
            _typeNameTable[4] = "System.Collections.ObjectModel.Collection`1<CDataBinding.Set>";
            _typeNameTable[5] = "Object";
            _typeNameTable[6] = "CDataBinding.Set";
            _typeNameTable[7] = "String";
            _typeNameTable[8] = "Int32";
            _typeNameTable[9] = "System.Collections.Generic.IList`1<Object>";
            _typeNameTable[10] = "System.Nullable`1<Boolean>";
            _typeNameTable[11] = "System.ValueType";

            _typeTable = new global::System.Type[12];
            _typeTable[0] = typeof(global::CDataBinding.MainPage);
            _typeTable[1] = typeof(global::Windows.UI.Xaml.Controls.Page);
            _typeTable[2] = typeof(global::Windows.UI.Xaml.Controls.UserControl);
            _typeTable[3] = typeof(global::System.Collections.ObjectModel.ObservableCollection<global::CDataBinding.Set>);
            _typeTable[4] = typeof(global::System.Collections.ObjectModel.Collection<global::CDataBinding.Set>);
            _typeTable[5] = typeof(global::System.Object);
            _typeTable[6] = typeof(global::CDataBinding.Set);
            _typeTable[7] = typeof(global::System.String);
            _typeTable[8] = typeof(global::System.Int32);
            _typeTable[9] = typeof(global::System.Collections.Generic.IList<global::System.Object>);
            _typeTable[10] = typeof(global::System.Nullable<global::System.Boolean>);
            _typeTable[11] = typeof(global::System.ValueType);
        }

        private int LookupTypeIndexByName(string typeName)
        {
            if (_typeNameTable == null)
            {
                InitTypeTables();
            }
            for (int i=0; i<_typeNameTable.Length; i++)
            {
                if(0 == string.CompareOrdinal(_typeNameTable[i], typeName))
                {
                    return i;
                }
            }
            return -1;
        }

        private int LookupTypeIndexByType(global::System.Type type)
        {
            if (_typeTable == null)
            {
                InitTypeTables();
            }
            for(int i=0; i<_typeTable.Length; i++)
            {
                if(type == _typeTable[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private object Activate_0_MainPage() { return new global::CDataBinding.MainPage(); }
        private object Activate_3_ObservableCollection() { return new global::System.Collections.ObjectModel.ObservableCollection<global::CDataBinding.Set>(); }
        private object Activate_4_Collection() { return new global::System.Collections.ObjectModel.Collection<global::CDataBinding.Set>(); }
        private void VectorAdd_3_ObservableCollection(object instance, object item)
        {
            var collection = (global::System.Collections.Generic.ICollection<global::CDataBinding.Set>)instance;
            var newItem = (global::CDataBinding.Set)item;
            collection.Add(newItem);
        }
        private void VectorAdd_4_Collection(object instance, object item)
        {
            var collection = (global::System.Collections.Generic.ICollection<global::CDataBinding.Set>)instance;
            var newItem = (global::CDataBinding.Set)item;
            collection.Add(newItem);
        }
        private void VectorAdd_9_IList(object instance, object item)
        {
            var collection = (global::System.Collections.Generic.ICollection<global::System.Object>)instance;
            var newItem = (global::System.Object)item;
            collection.Add(newItem);
        }

        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(int typeIndex)
        {
            global::CDataBinding.CDataBinding_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType userType;
            string typeName = _typeNameTable[typeIndex];
            global::System.Type type = _typeTable[typeIndex];

            switch (typeIndex)
            {

            case 0:   //  CDataBinding.MainPage
                userType = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_0_MainPage;
                userType.AddMemberName("MagicSets");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 1:   //  Windows.UI.Xaml.Controls.Page
                xamlType = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 2:   //  Windows.UI.Xaml.Controls.UserControl
                xamlType = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 3:   //  System.Collections.ObjectModel.ObservableCollection`1<CDataBinding.Set>
                userType = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("System.Collections.ObjectModel.Collection`1<CDataBinding.Set>"));
                userType.CollectionAdd = VectorAdd_3_ObservableCollection;
                userType.SetIsReturnTypeStub();
                xamlType = userType;
                break;

            case 4:   //  System.Collections.ObjectModel.Collection`1<CDataBinding.Set>
                userType = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_4_Collection;
                userType.CollectionAdd = VectorAdd_4_Collection;
                xamlType = userType;
                break;

            case 5:   //  Object
                xamlType = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 6:   //  CDataBinding.Set
                userType = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.AddMemberName("setImageUrl");
                userType.AddMemberName("code");
                userType.AddMemberName("name");
                userType.AddMemberName("type");
                userType.AddMemberName("border");
                userType.AddMemberName("mkm_id");
                userType.AddMemberName("booster");
                userType.AddMemberName("mkm_name");
                userType.AddMemberName("releaseDate");
                userType.AddMemberName("gathererCode");
                userType.AddMemberName("magicCardsInfoCode");
                userType.AddMemberName("block");
                userType.AddMemberName("oldCode");
                userType.AddMemberName("onlineOnly");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 7:   //  String
                xamlType = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 8:   //  Int32
                xamlType = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 9:   //  System.Collections.Generic.IList`1<Object>
                userType = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType(this, typeName, type, null);
                userType.CollectionAdd = VectorAdd_9_IList;
                userType.SetIsReturnTypeStub();
                xamlType = userType;
                break;

            case 10:   //  System.Nullable`1<Boolean>
                userType = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("System.ValueType"));
                userType.SetIsReturnTypeStub();
                xamlType = userType;
                break;

            case 11:   //  System.ValueType
                userType = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                xamlType = userType;
                break;
            }
            return xamlType;
        }


        private object get_0_MainPage_MagicSets(object instance)
        {
            var that = (global::CDataBinding.MainPage)instance;
            return that.MagicSets;
        }
        private void set_0_MainPage_MagicSets(object instance, object Value)
        {
            var that = (global::CDataBinding.MainPage)instance;
            that.MagicSets = (global::System.Collections.ObjectModel.ObservableCollection<global::CDataBinding.Set>)Value;
        }
        private object get_1_Set_setImageUrl(object instance)
        {
            var that = (global::CDataBinding.Set)instance;
            return that.setImageUrl;
        }
        private void set_1_Set_setImageUrl(object instance, object Value)
        {
            var that = (global::CDataBinding.Set)instance;
            that.setImageUrl = (global::System.String)Value;
        }
        private object get_2_Set_code(object instance)
        {
            var that = (global::CDataBinding.Set)instance;
            return that.code;
        }
        private void set_2_Set_code(object instance, object Value)
        {
            var that = (global::CDataBinding.Set)instance;
            that.code = (global::System.String)Value;
        }
        private object get_3_Set_name(object instance)
        {
            var that = (global::CDataBinding.Set)instance;
            return that.name;
        }
        private void set_3_Set_name(object instance, object Value)
        {
            var that = (global::CDataBinding.Set)instance;
            that.name = (global::System.String)Value;
        }
        private object get_4_Set_type(object instance)
        {
            var that = (global::CDataBinding.Set)instance;
            return that.type;
        }
        private void set_4_Set_type(object instance, object Value)
        {
            var that = (global::CDataBinding.Set)instance;
            that.type = (global::System.String)Value;
        }
        private object get_5_Set_border(object instance)
        {
            var that = (global::CDataBinding.Set)instance;
            return that.border;
        }
        private void set_5_Set_border(object instance, object Value)
        {
            var that = (global::CDataBinding.Set)instance;
            that.border = (global::System.String)Value;
        }
        private object get_6_Set_mkm_id(object instance)
        {
            var that = (global::CDataBinding.Set)instance;
            return that.mkm_id;
        }
        private void set_6_Set_mkm_id(object instance, object Value)
        {
            var that = (global::CDataBinding.Set)instance;
            that.mkm_id = (global::System.Int32)Value;
        }
        private object get_7_Set_booster(object instance)
        {
            var that = (global::CDataBinding.Set)instance;
            return that.booster;
        }
        private void set_7_Set_booster(object instance, object Value)
        {
            var that = (global::CDataBinding.Set)instance;
            that.booster = (global::System.Collections.Generic.IList<global::System.Object>)Value;
        }
        private object get_8_Set_mkm_name(object instance)
        {
            var that = (global::CDataBinding.Set)instance;
            return that.mkm_name;
        }
        private void set_8_Set_mkm_name(object instance, object Value)
        {
            var that = (global::CDataBinding.Set)instance;
            that.mkm_name = (global::System.String)Value;
        }
        private object get_9_Set_releaseDate(object instance)
        {
            var that = (global::CDataBinding.Set)instance;
            return that.releaseDate;
        }
        private void set_9_Set_releaseDate(object instance, object Value)
        {
            var that = (global::CDataBinding.Set)instance;
            that.releaseDate = (global::System.String)Value;
        }
        private object get_10_Set_gathererCode(object instance)
        {
            var that = (global::CDataBinding.Set)instance;
            return that.gathererCode;
        }
        private void set_10_Set_gathererCode(object instance, object Value)
        {
            var that = (global::CDataBinding.Set)instance;
            that.gathererCode = (global::System.String)Value;
        }
        private object get_11_Set_magicCardsInfoCode(object instance)
        {
            var that = (global::CDataBinding.Set)instance;
            return that.magicCardsInfoCode;
        }
        private void set_11_Set_magicCardsInfoCode(object instance, object Value)
        {
            var that = (global::CDataBinding.Set)instance;
            that.magicCardsInfoCode = (global::System.String)Value;
        }
        private object get_12_Set_block(object instance)
        {
            var that = (global::CDataBinding.Set)instance;
            return that.block;
        }
        private void set_12_Set_block(object instance, object Value)
        {
            var that = (global::CDataBinding.Set)instance;
            that.block = (global::System.String)Value;
        }
        private object get_13_Set_oldCode(object instance)
        {
            var that = (global::CDataBinding.Set)instance;
            return that.oldCode;
        }
        private void set_13_Set_oldCode(object instance, object Value)
        {
            var that = (global::CDataBinding.Set)instance;
            that.oldCode = (global::System.String)Value;
        }
        private object get_14_Set_onlineOnly(object instance)
        {
            var that = (global::CDataBinding.Set)instance;
            return that.onlineOnly;
        }
        private void set_14_Set_onlineOnly(object instance, object Value)
        {
            var that = (global::CDataBinding.Set)instance;
            that.onlineOnly = (global::System.Nullable<global::System.Boolean>)Value;
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember xamlMember = null;
            global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "CDataBinding.MainPage.MagicSets":
                userType = (global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CDataBinding.MainPage");
                xamlMember = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember(this, "MagicSets", "System.Collections.ObjectModel.ObservableCollection`1<CDataBinding.Set>");
                xamlMember.Getter = get_0_MainPage_MagicSets;
                xamlMember.Setter = set_0_MainPage_MagicSets;
                break;
            case "CDataBinding.Set.setImageUrl":
                userType = (global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CDataBinding.Set");
                xamlMember = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember(this, "setImageUrl", "String");
                xamlMember.Getter = get_1_Set_setImageUrl;
                xamlMember.Setter = set_1_Set_setImageUrl;
                break;
            case "CDataBinding.Set.code":
                userType = (global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CDataBinding.Set");
                xamlMember = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember(this, "code", "String");
                xamlMember.Getter = get_2_Set_code;
                xamlMember.Setter = set_2_Set_code;
                break;
            case "CDataBinding.Set.name":
                userType = (global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CDataBinding.Set");
                xamlMember = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember(this, "name", "String");
                xamlMember.Getter = get_3_Set_name;
                xamlMember.Setter = set_3_Set_name;
                break;
            case "CDataBinding.Set.type":
                userType = (global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CDataBinding.Set");
                xamlMember = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember(this, "type", "String");
                xamlMember.Getter = get_4_Set_type;
                xamlMember.Setter = set_4_Set_type;
                break;
            case "CDataBinding.Set.border":
                userType = (global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CDataBinding.Set");
                xamlMember = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember(this, "border", "String");
                xamlMember.Getter = get_5_Set_border;
                xamlMember.Setter = set_5_Set_border;
                break;
            case "CDataBinding.Set.mkm_id":
                userType = (global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CDataBinding.Set");
                xamlMember = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember(this, "mkm_id", "Int32");
                xamlMember.Getter = get_6_Set_mkm_id;
                xamlMember.Setter = set_6_Set_mkm_id;
                break;
            case "CDataBinding.Set.booster":
                userType = (global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CDataBinding.Set");
                xamlMember = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember(this, "booster", "System.Collections.Generic.IList`1<Object>");
                xamlMember.Getter = get_7_Set_booster;
                xamlMember.Setter = set_7_Set_booster;
                break;
            case "CDataBinding.Set.mkm_name":
                userType = (global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CDataBinding.Set");
                xamlMember = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember(this, "mkm_name", "String");
                xamlMember.Getter = get_8_Set_mkm_name;
                xamlMember.Setter = set_8_Set_mkm_name;
                break;
            case "CDataBinding.Set.releaseDate":
                userType = (global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CDataBinding.Set");
                xamlMember = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember(this, "releaseDate", "String");
                xamlMember.Getter = get_9_Set_releaseDate;
                xamlMember.Setter = set_9_Set_releaseDate;
                break;
            case "CDataBinding.Set.gathererCode":
                userType = (global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CDataBinding.Set");
                xamlMember = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember(this, "gathererCode", "String");
                xamlMember.Getter = get_10_Set_gathererCode;
                xamlMember.Setter = set_10_Set_gathererCode;
                break;
            case "CDataBinding.Set.magicCardsInfoCode":
                userType = (global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CDataBinding.Set");
                xamlMember = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember(this, "magicCardsInfoCode", "String");
                xamlMember.Getter = get_11_Set_magicCardsInfoCode;
                xamlMember.Setter = set_11_Set_magicCardsInfoCode;
                break;
            case "CDataBinding.Set.block":
                userType = (global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CDataBinding.Set");
                xamlMember = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember(this, "block", "String");
                xamlMember.Getter = get_12_Set_block;
                xamlMember.Setter = set_12_Set_block;
                break;
            case "CDataBinding.Set.oldCode":
                userType = (global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CDataBinding.Set");
                xamlMember = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember(this, "oldCode", "String");
                xamlMember.Getter = get_13_Set_oldCode;
                xamlMember.Setter = set_13_Set_oldCode;
                break;
            case "CDataBinding.Set.onlineOnly":
                userType = (global::CDataBinding.CDataBinding_XamlTypeInfo.XamlUserType)GetXamlTypeByName("CDataBinding.Set");
                xamlMember = new global::CDataBinding.CDataBinding_XamlTypeInfo.XamlMember(this, "onlineOnly", "System.Nullable`1<Boolean>");
                xamlMember.Getter = get_14_Set_onlineOnly;
                xamlMember.Setter = set_14_Set_onlineOnly;
                break;
            }
            return xamlMember;
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType
    {
        string _fullName;
        global::System.Type _underlyingType;

        public XamlSystemBaseType(string fullName, global::System.Type underlyingType)
        {
            _fullName = fullName;
            _underlyingType = underlyingType;
        }

        public string FullName { get { return _fullName; } }

        public global::System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        virtual public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name) { throw new global::System.NotImplementedException(); }
        virtual public bool IsArray { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsCollection { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsConstructible { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsDictionary { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsMarkupExtension { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsBindable { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsReturnTypeStub { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsLocalType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType ItemType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType KeyType { get { throw new global::System.NotImplementedException(); } }
        virtual public object ActivateInstance() { throw new global::System.NotImplementedException(); }
        virtual public void AddToMap(object instance, object key, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void AddToVector(object instance, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void RunInitializer()   { throw new global::System.NotImplementedException(); }
        virtual public object CreateFromString(string input)   { throw new global::System.NotImplementedException(); }
    }
    
    internal delegate object Activator();
    internal delegate void AddToCollection(object instance, object item);
    internal delegate void AddToDictionary(object instance, object key, object item);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlUserType : global::CDataBinding.CDataBinding_XamlTypeInfo.XamlSystemBaseType
    {
        global::CDataBinding.CDataBinding_XamlTypeInfo.XamlTypeInfoProvider _provider;
        global::Windows.UI.Xaml.Markup.IXamlType _baseType;
        bool _isArray;
        bool _isMarkupExtension;
        bool _isBindable;
        bool _isReturnTypeStub;
        bool _isLocalType;

        string _contentPropertyName;
        string _itemTypeName;
        string _keyTypeName;
        global::System.Collections.Generic.Dictionary<string, string> _memberNames;
        global::System.Collections.Generic.Dictionary<string, object> _enumValues;

        public XamlUserType(global::CDataBinding.CDataBinding_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
            :base(fullName, fullType)
        {
            _provider = provider;
            _baseType = baseType;
        }

        // --- Interface methods ----

        override public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { return _baseType; } }
        override public bool IsArray { get { return _isArray; } }
        override public bool IsCollection { get { return (CollectionAdd != null); } }
        override public bool IsConstructible { get { return (Activator != null); } }
        override public bool IsDictionary { get { return (DictionaryAdd != null); } }
        override public bool IsMarkupExtension { get { return _isMarkupExtension; } }
        override public bool IsBindable { get { return _isBindable; } }
        override public bool IsReturnTypeStub { get { return _isReturnTypeStub; } }
        override public bool IsLocalType { get { return _isLocalType; } }

        override public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty
        {
            get { return _provider.GetMemberByLongName(_contentPropertyName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType ItemType
        {
            get { return _provider.GetXamlTypeByName(_itemTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType KeyType
        {
            get { return _provider.GetXamlTypeByName(_keyTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name)
        {
            if (_memberNames == null)
            {
                return null;
            }
            string longName;
            if (_memberNames.TryGetValue(name, out longName))
            {
                return _provider.GetMemberByLongName(longName);
            }
            return null;
        }

        override public object ActivateInstance()
        {
            return Activator(); 
        }

        override public void AddToMap(object instance, object key, object item) 
        {
            DictionaryAdd(instance, key, item);
        }

        override public void AddToVector(object instance, object item)
        {
            CollectionAdd(instance, item);
        }

        override public void RunInitializer() 
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(UnderlyingType.TypeHandle);
        }

        override public object CreateFromString(string input)
        {
            if (_enumValues != null)
            {
                int value = 0;

                string[] valueParts = input.Split(',');

                foreach (string valuePart in valueParts) 
                {
                    object partValue;
                    int enumFieldValue = 0;
                    try
                    {
                        if (_enumValues.TryGetValue(valuePart.Trim(), out partValue))
                        {
                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                        }
                        else
                        {
                            try
                            {
                                enumFieldValue = global::System.Convert.ToInt32(valuePart.Trim());
                            }
                            catch( global::System.FormatException )
                            {
                                foreach( string key in _enumValues.Keys )
                                {
                                    if( string.Compare(valuePart.Trim(), key, global::System.StringComparison.OrdinalIgnoreCase) == 0 )
                                    {
                                        if( _enumValues.TryGetValue(key.Trim(), out partValue) )
                                        {
                                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        value |= enumFieldValue; 
                    }
                    catch( global::System.FormatException )
                    {
                        throw new global::System.ArgumentException(input, FullName);
                    }
                }

                return value; 
            }
            throw new global::System.ArgumentException(input, FullName);
        }

        // --- End of Interface methods

        public Activator Activator { get; set; }
        public AddToCollection CollectionAdd { get; set; }
        public AddToDictionary DictionaryAdd { get; set; }

        public void SetContentPropertyName(string contentPropertyName)
        {
            _contentPropertyName = contentPropertyName;
        }

        public void SetIsArray()
        {
            _isArray = true; 
        }

        public void SetIsMarkupExtension()
        {
            _isMarkupExtension = true;
        }

        public void SetIsBindable()
        {
            _isBindable = true;
        }

        public void SetIsReturnTypeStub()
        {
            _isReturnTypeStub = true;
        }

        public void SetIsLocalType()
        {
            _isLocalType = true;
        }

        public void SetItemTypeName(string itemTypeName)
        {
            _itemTypeName = itemTypeName;
        }

        public void SetKeyTypeName(string keyTypeName)
        {
            _keyTypeName = keyTypeName;
        }

        public void AddMemberName(string shortName)
        {
            if(_memberNames == null)
            {
                _memberNames =  new global::System.Collections.Generic.Dictionary<string,string>();
            }
            _memberNames.Add(shortName, FullName + "." + shortName);
        }

        public void AddEnumValue(string name, object value)
        {
            if (_enumValues == null)
            {
                _enumValues = new global::System.Collections.Generic.Dictionary<string, object>();
            }
            _enumValues.Add(name, value);
        }
    }

    internal delegate object Getter(object instance);
    internal delegate void Setter(object instance, object value);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember
    {
        global::CDataBinding.CDataBinding_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::CDataBinding.CDataBinding_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
        {
            _name = name;
            _typeName = typeName;
            _provider = provider;
        }

        public string Name { get { return _name; } }

        public global::Windows.UI.Xaml.Markup.IXamlType Type
        {
            get { return _provider.GetXamlTypeByName(_typeName); }
        }

        public void SetTargetTypeName(string targetTypeName)
        {
            _targetTypeName = targetTypeName;
        }
        public global::Windows.UI.Xaml.Markup.IXamlType TargetType
        {
            get { return _provider.GetXamlTypeByName(_targetTypeName); }
        }

        public void SetIsAttachable() { _isAttachable = true; }
        public bool IsAttachable { get { return _isAttachable; } }

        public void SetIsDependencyProperty() { _isDependencyProperty = true; }
        public bool IsDependencyProperty { get { return _isDependencyProperty; } }

        public void SetIsReadOnly() { _isReadOnly = true; }
        public bool IsReadOnly { get { return _isReadOnly; } }

        public Getter Getter { get; set; }
        public object GetValue(object instance)
        {
            if (Getter != null)
                return Getter(instance);
            else
                throw new global::System.InvalidOperationException("GetValue");
        }

        public Setter Setter { get; set; }
        public void SetValue(object instance, object value)
        {
            if (Setter != null)
                Setter(instance, value);
            else
                throw new global::System.InvalidOperationException("SetValue");
        }
    }
}
