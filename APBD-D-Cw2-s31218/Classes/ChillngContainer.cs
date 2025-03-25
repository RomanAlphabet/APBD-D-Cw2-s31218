using APBD_D_Cw2_s31218.Interfaces;

namespace APBD_D_Cw2_s31218.Classes;

public class ChillingContainer(double height, double contMass, double depth, double maxLoadMass, string productType, double temperature) : Container(height, contMass, depth, maxLoadMass, "KON-C-" + Id++), IHazardNotifier
{
    public string ProductType { get; set;  } = productType;
    public double Temperature { get; set;  } = temperature;
    
    private static readonly Dictionary<string, double> ProductTemperatures = new()
    {
        ["Bananas"] = 13.3,
        ["Chocolate"] = 18.0,
        ["Fish"] = 2.0,
        ["Meat"] = -15.0,
        ["Ice Cream"] = -18.0,
        ["Frozen Pizza"] = -30.0,
        ["Cheese"] = 7.2,
        ["Sausages"] = 5.0,
        ["Butter"] = 20.5,
        ["Eggs"] = 19.0
    };

    public void Load(double mass, string productType, double temperature)
    {
        double productTemp;
        try
        {
            productTemp = ProductTemperatures[productType];
        }
        catch (Exception)
        {
            Console.WriteLine("Wrong product type. Nothing added");
            return;
        }
        
        if (!ProductType.Equals(productType))
        {
            Console.WriteLine("ERROR: Invalid product type");
        }
        else
        {
            if (Temperature < temperature && Temperature < productTemp)
            {
                Console.WriteLine("ERROR: Invalid temperature");
            }
            else
            {
                base.Load(mass);
            }
        }
    }

    public void Notify()
    {
        Console.WriteLine($"Dangerous action detected in gas container: {SerialNo}");
    }
    
    public override string ToString()
    {
        return $"[{GetType().Name}] -- LoadMass: {LoadMass}, Height: {Height}, ContMass: {ContMass}, Depth: {Depth}, MaxLoadMass: {MaxLoadMass}, ProductType: {ProductType}, Temperature: {Temperature}";
    }
    
}