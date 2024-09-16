namespace api.Util.Enum
{
    public enum  ResponseEnum
    {
        Error = 0,
        Success = 1,
        Created = 2,
        NoCreated = 3,
        Modified = 4,
        NoModified = 5,
        InexistentId = 6,
        NotFound = 7,
        InvalidPayload = 8,
        PlaceReservedForThisDate = 9,    
        InvalidFields = 10,
        NoVacancy = 11,
        PlaceInexistent = 12,
        Unauthorized = 13,
        AlreadySubscriber = 14,
        TrainingDateHasPassed = 15,
        MicrosoftGraphError = 16,
        Forbbiden = 17,
        NullError = 18,
        InternalServerError = 19,
        BadRequest = 20,
        DbUpdateError = 21,
        DateHasPassed = 22

    }
}