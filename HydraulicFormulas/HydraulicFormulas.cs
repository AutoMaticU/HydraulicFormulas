/// <summary>
/// This class provides c# implementation for basic hydraulic formulas
/// 
/// - Reynolds Number (explicit)
/// - Colebrook-White (implicit)
/// 
/// Author: J. Xavier Atero
/// </summary>

using System;
using MathNet.Numerics.RootFinding;

namespace Automaticu.HydraulicFormulas
{
   public class HydraulicFormulas
   {

      /// <summary>
      /// Reynolds number for flow in a pipe = ρuDH/μ
      /// 
      /// https://en.wikipedia.org/wiki/Reynolds_number
      /// </summary>
      public static double ReynoldsNumberInPipe_rouDH_by_mu(double ro_density, double u_mean_velocity, double DH_hydraulic_diameter, double mu_dynamic_viscosity) {
         return (ro_density * u_mean_velocity * DH_hydraulic_diameter) / mu_dynamic_viscosity;
      }

      /// <summary>
      /// Reynolds number for flow in a pipe = ρu4A/μP
      /// 
      /// https://en.wikipedia.org/wiki/Reynolds_number
      /// </summary>
      public static double ReynoldsNumberInPipe_rou4A_by_muP(double ro_density, double u_mean_velocity, double A_cross_sectional_area, double mu_dynamic_viscosity, double P_wetted_perimeter)
      {
         return (ro_density * u_mean_velocity * 4 * A_cross_sectional_area) / (mu_dynamic_viscosity * P_wetted_perimeter);
      }

      /// <summary>
      /// Reynolds number for flow in a pipe = ρQDH/μA
      /// 
      /// https://en.wikipedia.org/wiki/Reynolds_number
      /// </summary>
      public static double ReynoldsNumberInPipe_roQDH_by_muA(double ro_density, double Q_flow_rate, double DH_hydraulic_diameter, double mu_dynamic_viscosity, double A_cross_sectional_area)
      {
         return (ro_density * Q_flow_rate * DH_hydraulic_diameter) / (mu_dynamic_viscosity * A_cross_sectional_area);
      }

      /// <summary>
      /// Reynolds number for flow in a pipe = ρQ4/μP
      /// 
      /// https://en.wikipedia.org/wiki/Reynolds_number
      /// </summary>
      public static double ReynoldsNumberInPipe_roQ4_by_muP(double ro_density, double Q_flow_rate, double mu_dynamic_viscosity, double P_wetted_perimeter)
      {
         return (ro_density * Q_flow_rate * 4) / (mu_dynamic_viscosity * P_wetted_perimeter);
      }

      /// <summary>
      /// Reynolds number for flow in a pipe = uDH/ν
      /// 
      /// https://en.wikipedia.org/wiki/Reynolds_number
      /// </summary>
      public static double ReynoldsNumberInPipe_uDH_by_nu(double u_mean_velocity, double DH_hydraulic_diameter, double nu_kinematic_viscosity)
      {
         return (u_mean_velocity * DH_hydraulic_diameter) / nu_kinematic_viscosity;
      }

      /// <summary>
      /// Reynolds number for flow in a pipe = u4A/νP
      /// 
      /// https://en.wikipedia.org/wiki/Reynolds_number
      /// </summary>
      public static double ReynoldsNumberInPipe_u4A_by_nuP(double u_mean_velocity, double A_cross_sectional_area, double nu_kinematic_viscosity, double P_wetted_perimeter)
      {
         return (u_mean_velocity * 4 * A_cross_sectional_area) / (nu_kinematic_viscosity * P_wetted_perimeter);
      }

      /// <summary>
      /// Reynolds number for flow in a pipe = QDH/νA
      /// 
      /// https://en.wikipedia.org/wiki/Reynolds_number
      /// </summary>
      public static double ReynoldsNumberInPipe_QDH_by_nuA(double Q_flow_rate, double DH_hydraulic_diameter, double nu_kinematic_viscosity, double A_cross_sectional_area)
      {
         return (Q_flow_rate * DH_hydraulic_diameter) / (nu_kinematic_viscosity * A_cross_sectional_area);
      }

      /// <summary>
      /// Reynolds number for flow in a pipe = Q4/νP
      /// 
      /// https://en.wikipedia.org/wiki/Reynolds_number
      /// </summary>
      public static double ReynoldsNumberInPipe_Q4_by_nuP(double Q_flow_rate, double nu_kinematic_viscosity, double P_wetted_perimeter)
      {
         return (Q_flow_rate * 4) / (nu_kinematic_viscosity * P_wetted_perimeter);
      }

      /// <summary>
      /// Colebrook-White equation using Bisection
      /// 
      /// https://en.wikipedia.org/wiki/Darcy_friction_factor_formulae#Colebrook%E2%80%93White_equation
      /// </summary>
      public static double CollebrookWhiteBisection(double epsilon_relative_roughness, double DH_hydraulic_diameter, double Re_reynolds_number)
      {
         Func<double, double> func = u_f_friction_factor => (1 / Math.Sqrt(u_f_friction_factor)) + 2 * Math.Log10((epsilon_relative_roughness / (3.7 * DH_hydraulic_diameter)) + (2.51 / (Re_reynolds_number * Math.Sqrt(u_f_friction_factor))));

         return Bisection.FindRoot(func, 1e-4, 1, 1e-8);
      }

      /// <summary>
      /// Colebrook-White equation using Brent
      /// 
      /// https://en.wikipedia.org/wiki/Darcy_friction_factor_formulae#Colebrook%E2%80%93White_equation
      /// </summary>
      public static double CollebrookWhiteBrent(double epsilon_relative_roughness, double DH_hydraulic_diameter, double Re_reynolds_number)
      {
         Func<double, double> func = u_f_friction_factor => (1 / Math.Sqrt(u_f_friction_factor)) + 2 * Math.Log10((epsilon_relative_roughness / (3.7 * DH_hydraulic_diameter)) + (2.51 / (Re_reynolds_number * Math.Sqrt(u_f_friction_factor))));

         return Brent.FindRoot(func, 1e-4, 1, 1e-8);
      }
   }
}
