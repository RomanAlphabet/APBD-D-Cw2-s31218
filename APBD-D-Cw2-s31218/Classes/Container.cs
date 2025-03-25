using APBD_D_Cw2_s31218.Exceptions;
using APBD_D_Cw2_s31218.Interfaces;

namespace APBD_D_Cw2_s31218.Classes;

public abstract class Container(double height, double contMass, double depth, double maxLoadMass, string serialNo) : IContainer
{
    private protected static int Id = 1;

    public string SerialNo { get; } = serialNo;
    public double LoadMass { get; set; } = 0;
    public double Height { get; } = height;
    public double ContMass { get; } = contMass;
    public double Depth { get; } = depth;
    public double MaxLoadMass { get; } = maxLoadMass;


    public virtual void Load(double mass)
    {
        if (LoadMass + mass < MaxLoadMass)
        {
            LoadMass += mass;
        }
        else
        {
            throw new OverfillException("Load mass overfill");
        }
    }

    public virtual void Unload()
    {
        LoadMass = 0;
    }

    public override string ToString()
    {
        return $"[{GetType().Name}] -- LoadMass: {LoadMass}, Height: {Height}, ContMass: {ContMass}, Depth: {Depth}, MaxLoadMass: {MaxLoadMass}";
    }
}