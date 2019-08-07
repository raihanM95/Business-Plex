using AutoMapper;
using BusinessPlex.Models;
using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BusinessPlex
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Initialize AutoMapper
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.CreateMap<Category, CategoryViewModel>();

                cfg.CreateMap<ProductViewModel, Product>();
                cfg.CreateMap<Product, ProductViewModel>();

                cfg.CreateMap<CustomerViewModel, Customer>();
                cfg.CreateMap<Customer, CustomerViewModel>();

                cfg.CreateMap<SupplierViewModel, Supplier>();
                cfg.CreateMap<Supplier, SupplierViewModel>();
            });
        }
    }
}
