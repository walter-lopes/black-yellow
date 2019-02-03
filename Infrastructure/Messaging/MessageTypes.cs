using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.Infrastructure.Messaging
{
    public enum MessageTypes
    {
        // General
        Unknown,

        // Commands
        RegisterCustomer,
        RegisterVehicle,
        PlanMaintenanceJob,
        FinishMaintenanceJob,

        // Events
        DayHasPassed,
        CustomerRegistered,
        VehicleRegistered,
        WorkshopPlanningCreated,
        MaintenanceJobPlanned,
        MaintenanceJobFinished
    }
}
