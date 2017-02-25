namespace SharpStore.Data
{
    class Data
    {
        private static SharpStoreContext context;

        public static SharpStoreContext Context => context ?? (context = new SharpStoreContext());
    }
}
