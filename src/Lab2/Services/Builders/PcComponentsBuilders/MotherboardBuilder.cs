using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcComponentsBuilders;

public class MotherboardBuilder
{
    private string? _name;
    private Socket? _socket;
    private int? _numOfPcieLines;
    private int? _numOfSataPorts;
    private Chipset? _chipset;
    private DddrStandardVersion? _supportedDddr;
    private int? _numOfRamSlots;
    private MotherboardFormFactor? _formFactor;
    private Bios? _bios;

    public MotherboardBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public MotherboardBuilder WithSocket(Socket socket)
    {
        _socket = socket;

        return this;
    }

    public MotherboardBuilder WithNumOfPcieLines(int numOfPcieLines)
    {
        if (numOfPcieLines < 0) throw new NegativeArgumentException(nameof(numOfPcieLines));

        _numOfPcieLines = numOfPcieLines;

        return this;
    }

    public MotherboardBuilder WithNumOfSataPorts(int numOfSataPorts)
    {
        if (numOfSataPorts < 0) throw new NegativeArgumentException(nameof(numOfSataPorts));

        _numOfSataPorts = numOfSataPorts;

        return this;
    }

    public MotherboardBuilder WithChipset(Chipset chipset)
    {
        _chipset = chipset;

        return this;
    }

    public MotherboardBuilder WithSupportedDddr(DddrStandardVersion dddr)
    {
        _supportedDddr = dddr;

        return this;
    }

    public MotherboardBuilder WithNumOfRamSlots(int numOfRamSlots)
    {
        if (numOfRamSlots < 0) throw new NegativeArgumentException(nameof(numOfRamSlots));

        _numOfRamSlots = numOfRamSlots;

        return this;
    }

    public MotherboardBuilder WithFormFactor(MotherboardFormFactor formFactor)
    {
        _formFactor = formFactor;

        return this;
    }

    public MotherboardBuilder WithBios(Bios bios)
    {
        _bios = bios;

        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _numOfPcieLines ?? throw new ArgumentNullException(nameof(_numOfPcieLines)),
            _numOfSataPorts ?? throw new ArgumentNullException(nameof(_numOfSataPorts)),
            _chipset ?? throw new ArgumentNullException(nameof(_chipset)),
            _supportedDddr ?? throw new ArgumentNullException(nameof(_supportedDddr)),
            _numOfRamSlots ?? throw new ArgumentNullException(nameof(_numOfRamSlots)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)));
    }

    public MotherboardBuilder Direct(Motherboard pcComponent)
    {
        if (pcComponent == null)
        {
            throw new ArgumentNullException(nameof(pcComponent));
        }

        _name = pcComponent.Name;
        _socket = pcComponent.Socket;
        _chipset = pcComponent.Chipset;
        _numOfPcieLines = pcComponent.NumOfPcieLines;
        _bios = pcComponent.Bios;
        _formFactor = pcComponent.FormFactor;
        _supportedDddr = pcComponent.SupportedDddr;
        _numOfRamSlots = pcComponent.NumOfRamSlots;
        _numOfSataPorts = pcComponent.NumOfSataPorts;

        return this;
    }
}