using System;
using System.Collections.Generic;
using LinqToDB;
using System.Linq;

namespace addressbook_web_tests
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base(ProviderName.MySql, @"server=localhost; database=addressbook; port = 3306; Uid=root;Pwd=;charset=utf8; Allow Zero Datetime = true")
        { }


        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }

        public ITable<ContactData> Contacts { get { return GetTable<ContactData>(); } }

        public ITable<GroupContactRelation> GCR { get { return GetTable<GroupContactRelation>(); } }

    }
}

