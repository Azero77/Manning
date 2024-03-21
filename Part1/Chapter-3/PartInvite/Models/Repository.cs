namespace PartInvite.Models
{
    public static class Repository
    {
        private static List<GuestResponse> ResponsesList = new();
        public static IEnumerable<GuestResponse> GetResponses => ResponsesList;

        public static void AddResponse(GuestResponse Response)
        {
            ResponsesList.Add(Response);
            Console.WriteLine(Response);
        }
    }
}
