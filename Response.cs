namespace McDonalds;

public record Response<Any>(int status_code, string? description, Any? result);
