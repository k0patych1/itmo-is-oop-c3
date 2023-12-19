using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public interface IPcComponentValidator
{
    public ValidationReport Validate([NotNull] Pc pc);
}