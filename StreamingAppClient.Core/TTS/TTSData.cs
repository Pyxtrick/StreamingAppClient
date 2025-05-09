﻿namespace StreamingAppClient.Core.TTS;

public class TTSData
{
    public int Id { get; set; }

    public string Message { get; set; }

    public string OriginalMessage { get; set; }

    public int MessageLengthSeconds { get; set; }

    public bool IsActive { get; set; }

    public DateTime Posted { get; set; }
}
