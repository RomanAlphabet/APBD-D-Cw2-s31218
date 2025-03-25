// See https://aka.ms/new-console-template for more information

using APBD_D_Cw2_s31218.Classes;

CargoShip cargoShip = new CargoShip(100, 150, 15000);

LiquidContainer liquidContainer1 = new LiquidContainer(100, 10, 200, 1000, false);
liquidContainer1.Load(500);
ChillingContainer chillingContainer1 = new ChillingContainer(100, 50, 200, 900, "Bananas", 15);
chillingContainer1.Load(500, "Bananas", 11);
GasContainer gasContainer1 = new GasContainer(100, 30, 200, 1000, 100);
gasContainer1.Load(160);

cargoShip.LoadContainer(liquidContainer1);

cargoShip.LoadContainer([chillingContainer1, gasContainer1]);

Console.WriteLine(cargoShip.Containers.Count);

cargoShip.UnloadContainer(liquidContainer1.SerialNo);

Console.WriteLine(string.Join(Environment.NewLine, cargoShip.Containers));

GasContainer gasContainer2 = new GasContainer(100, 30, 200, 2000, 100);
gasContainer2.Load(1600);

cargoShip.ReplaceContainer(chillingContainer1.SerialNo, gasContainer2);

Console.WriteLine();
Console.WriteLine(string.Join('\n', cargoShip.Containers));

cargoShip.ShowCargoShipInfo();
Console.WriteLine();

CargoShip cargoShip2 = new CargoShip(60, 100, 10000);
cargoShip.MoveContainer(gasContainer1.SerialNo, cargoShip2);

Console.WriteLine("CargoShip1:");
cargoShip.ShowCargoShipInfo();
Console.WriteLine();
Console.WriteLine("CargoShip2:");
cargoShip2.ShowCargoShipInfo();