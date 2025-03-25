using APBD_D_Cw2_s31218.Interfaces;

namespace APBD_D_Cw2_s31218.Classes;

public class GasContainer(double height, double contMass, double depth, double maxLoadMass, double pressure) : Container(height, contMass, depth, maxLoadMass, "KON-G-" + Id++), IHazardNotifier
{
    
    public double Pressure { get; set; } = pressure;
    
    public override void Unload()
    {
        LoadMass *= 0.05;
    }

    public void Notify()
    {
        Console.WriteLine($"Dangerous action detected in gas container: {SerialNo}");
    }
    
    public override string ToString()
    {
        return $"[{GetType().Name}] -- LoadMass: {LoadMass}, Height: {Height}, ContMass: {ContMass}, Depth: {Depth}, MaxLoadMass: {MaxLoadMass}, Pressure: {Pressure}";
    }
}