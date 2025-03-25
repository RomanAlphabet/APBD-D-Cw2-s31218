namespace APBD_D_Cw2_s31218.Classes;

public class CargoShip(double speed, int maxContainersQuantity, double maxContainerWeight)
{
    
    public readonly List<Container> Containers = [];
    public double Speed { get; } = speed;
    public int MaxContainersQuantity { get; } = maxContainersQuantity;
    public double MaxContainerWeight { get; } = maxContainerWeight;

    public void LoadContainer(Container container) => Containers.Add(container);
    public void LoadContainer(List<Container> containers) => Containers.AddRange(containers);
    
    public void UnloadContainer(string serialNo)
    {
        if (Containers.Count > 0)
        {
            Containers.Remove(Containers.Find(c => c.SerialNo == serialNo));
        }
    }

    public void ReplaceContainer(string serialNo, Container container)
    {
        int index = Containers.FindIndex(c => c.SerialNo == serialNo);
        Containers.RemoveAt(index);
        Containers.Insert(index, container);
    }
    
    public void MoveContainer(string serialNo, CargoShip cargoShip)
    {
        int index = Containers.FindIndex(c => c.SerialNo == serialNo);
        Container tempContainer = Containers[index];
        Containers.RemoveAt(index);
        cargoShip.Containers.Add(tempContainer);
    }

    public override string ToString()
    {
        return $"[{GetType().Name}] -- Speed: {Speed}, MaxContainersQuantity: {MaxContainersQuantity}, MaxContainerWeight: {MaxContainerWeight}";
    }

    public void ShowCargoShipInfo()
    {
        Console.WriteLine("Cargo ship info:");
        Console.WriteLine(ToString());
        Console.WriteLine("Loaded containers info:");
        Console.WriteLine(string.Join('\n', Containers));
    }
    
}