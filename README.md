# OPC_DA_Proxy

architecture of this system is following:

iFIX Scada Simulation Server <---------------> C#'s OPC DA Client <----> C#'s REST API <---------------> Android Client App

Goal of this project is to read values from iFIX, store on server, forward to Android client