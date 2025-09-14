namespace Ecommerce.Shared.Authorization;

public static class Permissions
{
    public static class Product
    {
        public const string View = "Permissions.Product.View";
        public const string Create = "Permissions.Product.Create";
        public const string Edit = "Permissions.Product.Edit";
        public const string Delete = "Permissions.Product.Delete";
    }

    public static class Order
    {
        public const string View = "Permissions.Order.View";
        public const string Create = "Permissions.Order.Create";
        public const string Edit = "Permissions.Order.Edit";
        public const string Delete = "Permissions.Order.Delete";
        public const string Approve = "Permissions.Order.Approve";
    }

    public static class User
    {
        public const string View = "Permissions.User.View";
        public const string Create = "Permissions.User.Create";
        public const string Edit = "Permissions.User.Edit";
        public const string Delete = "Permissions.User.Delete";
        public const string AssignRole = "Permissions.User.AssignRole";
    }

    public static class Category
    {
        public const string View = "Permissions.Category.View";
        public const string Create = "Permissions.Category.Create";
        public const string Edit = "Permissions.Category.Edit";
        public const string Delete = "Permissions.Category.Delete";
    }
}