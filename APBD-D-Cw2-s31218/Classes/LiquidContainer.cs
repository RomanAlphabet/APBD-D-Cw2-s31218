using APBD_D_Cw2_s31218.Interfaces;

namespace APBD_D_Cw2_s31218.Classes;

public class LiquidContainer(double height, double contMass, double depth, double maxLoadMass, bool containsDangerousLiquid) : Container(height, contMass, depth, maxLoadMass, "KON-L-" + Id++), IHazardNotifier
{
    
    public bool ContainsDangerousLiquid { get; set; } = containsDangerousLiquid;

    public override void Load(double mass)
    {
        if (ContainsDangerousLiquid)
        {
            if (LoadMass + mass < maxLoadMass*0.5)
            {
                base.Load(mass);
            }
            else
            {
                Notify();
            }
        }
        else
        {
            if (LoadMass + mass < maxLoadMass*0.9)
            {
                base.Load(mass);
            }
            else
            {
                Notify();
            }
        }
    }

    public void Notify()
    {
        Console.WriteLine($"Dangerous action detected in liquid container: {SerialNo}");
    }
    
    public override string ToString()
    {
        return $"[{GetType().Name}] -- LoadMass: {LoadMass}, Height: {Height}, ContMass: {ContMass}, Depth: {Depth}, MaxLoadMass: {MaxLoadMass}, ContainsDangerousLiquid: {ContainsDangerousLiquid}";
    }
}