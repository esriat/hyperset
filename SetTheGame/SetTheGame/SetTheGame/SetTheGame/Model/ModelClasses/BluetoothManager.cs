using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SetTheGame.Model
{
    public class BluetoothManager
    {
        /*IBluetoothLE ble;
        IAdapter adapter;
        BluetoothState state;
        ObservableCollection<IDevice> deviceList;

        public BluetoothManager()
        {
            ble = CrossBluetoothLE.Current;
            state = ble.State;
            adapter = CrossBluetoothLE.Current.Adapter;
            deviceList = new ObservableCollection<IDevice>();

            ble.StateChanged += (s, a) =>
            {
                Console.WriteLine("L'état du bluetooth a changé");
            };
        }

        public async void ScanForDevices()
        {
            try
            {
                deviceList.Clear();
                adapter.DeviceDiscovered += (s, a) =>
                {
                    deviceList.Add(a.Device);
                };
                if (!ble.Adapter.IsScanning)
                {
                    await adapter.StartScanningForDevicesAsync();
                }
            } catch (Exception e)
            {
                Console.WriteLine("Yes");
            }
        }

        public async void connectToDevice()
        {
            for(int i = 0; i < deviceList.Count; i++)
            {
                /*if (deviceList[i].Name.Equals("MayPhone"))
                {
                    try
                    {
                        await adapter.ConnectToDeviceAsync(deviceList[i]);
                    } catch (Exception e)
                    {
                        Console.WriteLine("Echec");
                    }
                ]
            }
        }*/
    }
}
