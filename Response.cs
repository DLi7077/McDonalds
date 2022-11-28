namespace McDonalds;
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record
public record Response<Any>(
  int status_code,
  string? description,
  Any? result
);
