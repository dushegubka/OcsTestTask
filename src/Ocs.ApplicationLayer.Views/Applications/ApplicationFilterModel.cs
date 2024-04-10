using System.ComponentModel.DataAnnotations;

namespace Ocs.ApplicationLayer.Views.Applications;

public class ApplicationFilterModel
{
    private readonly string? _submittedAfter;
    private readonly string? _unsubmittedOlder;

    public string? SubmittedAfter
    {
        get => _submittedAfter;
        init => _submittedAfter = value?.Trim('#');

    }

    public string? UnsubmittedOlder
    {
        get => _unsubmittedOlder;
        init => _unsubmittedOlder = value?.Trim('#');
    }
}