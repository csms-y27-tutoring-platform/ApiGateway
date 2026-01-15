namespace ApiGateway.Infrastructure.Grpc.Mappings.Tutor;

public static class LessonFormatMapper
{
    public static LessonFormat ToGrpc(this Application.Models.Schedule.Enums.LessonFormat lessonFormat)
    {
        LessonFormat format = lessonFormat switch
        {
            Application.Models.Schedule.Enums.LessonFormat.Online => LessonFormat.Online,
            Application.Models.Schedule.Enums.LessonFormat.Offline => LessonFormat.Offline,
            Application.Models.Schedule.Enums.LessonFormat.Hybrid => LessonFormat.Hybrid,
            _ => throw new ArgumentOutOfRangeException(nameof(lessonFormat)),
        };
        return format;
    }

    public static Application.Models.Schedule.Enums.LessonFormat ToApplication(this LessonFormat lessonFormat)
    {
        Application.Models.Schedule.Enums.LessonFormat format = lessonFormat switch
        {
            LessonFormat.Online => Application.Models.Schedule.Enums.LessonFormat.Online,
            LessonFormat.Offline => Application.Models.Schedule.Enums.LessonFormat.Offline,
            LessonFormat.Hybrid => Application.Models.Schedule.Enums.LessonFormat.Hybrid,
            _ => throw new ArgumentOutOfRangeException(nameof(lessonFormat)),
        };
        return format;
    }
}