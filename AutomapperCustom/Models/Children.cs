﻿using AutoMapper;
using AutomapperTest.MapperFactory;
using AutomapperTest.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomapperCustom.Models
{
    public class Children : IChildren
    {
        public Children()
        {
        }
        public Children(IChildren children, bool flag = true)
        {
            var config = new MapperConfiguration(
                        cfg =>
                        {
                            cfg.CreateMap<Children, Children>()
                            .PreserveReferences();
                            cfg.CreateMap<ChildrenCollection, ChildrenCollection>()
                            .PreserveReferences();
                            cfg.CreateMap<List<ChildrenElements>, List<ChildrenElements>>();
                        });
            config.AssertConfigurationIsValid();
            var mapper = new Mapper(config);

            Name = "Test";
            FatherName = "TestFather";
            childrenCollection = new ChildrenCollection() { DefaultValue = -1, FullName = "Children Name 1", Enabled = false };
            if (children != null)
            {
                if (flag)
                {
                    /////////////////////////////////////////////////////////////////////
                    ////            Using Generic Mapper Configuration                ///
                    /////////////////////////////////////////////////////////////////////
                    mapper.Map(children, this);
                }
                else
                {
                    /////////////////////////////////////////////////////////////////////
                    ////       Using Profile Registration Mapper Configuration        ///
                    /////////////////////////////////////////////////////////////////////
                    mapper.Map(children, this);
                }
            }
        }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public ChildrenCollection childrenCollection { get; set; }
   }
    public class ChildrenCollection : CollectionBase<ChildrenElements>
    {
        public ChildrenCollection()
        {
        }
        public int DefaultValue { get; set; }
        }

    public class ChildrenElements
    {
        public string SchoolName { get; set; }
        public string CityName { get; set; }
    }
}