using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Automaticu.HydraulicFormulas.UnitTest
{
   [TestClass]
   public class UnitTestReynoldsNumber
   {
      [TestMethod]
      public void TestReynoldsNumberInRoundPipe()
      {
         double ro = 910; // kg / m3
         double u = 2.6; // m / s
         double DH = 0.00025; // m
         double mu = 0.38; // N s / m2
         double nu = mu / ro; // m / s
         // assuming circular pipe and half "wet"
         double radius = DH / 2; // m
         double A = Math.PI * Math.Pow(radius,2) / 2; // m2 (half of the area)
         double P = Math.PI * radius; // m (half of the perimeter)
         double Q = u * A; // m2 / s

         double reynolds_number_rouDH_by_mu = HydraulicFormulas.ReynoldsNumberInPipe_rouDH_by_mu(ro,u,DH,mu);
         double reynolds_number_rou4A_by_muP = HydraulicFormulas.ReynoldsNumberInPipe_rou4A_by_muP(ro,u,A,mu,P);
         double reynolds_number_roQDH_by_muA = HydraulicFormulas.ReynoldsNumberInPipe_roQDH_by_muA(ro, Q, DH, mu, A);
         double reynolds_number_roQ4_by_muP = HydraulicFormulas.ReynoldsNumberInPipe_roQ4_by_muP(ro, Q, mu, P);
         double reynolds_number_uDH_by_nu = HydraulicFormulas.ReynoldsNumberInPipe_uDH_by_nu(u, DH, nu);
         double reynolds_number_u4A_by_nuP = HydraulicFormulas.ReynoldsNumberInPipe_u4A_by_nuP(u, A, nu, P);
         double reynolds_number_QDH_by_nuA = HydraulicFormulas.ReynoldsNumberInPipe_QDH_by_nuA(Q, DH, nu, A);
         double reynolds_number_Q4_by_nuP = HydraulicFormulas.ReynoldsNumberInPipe_Q4_by_nuP(Q, nu, P);

         Assert.AreEqual(1.556579, Math.Round(reynolds_number_rouDH_by_mu,6));
         Assert.AreEqual(1.556579, Math.Round(reynolds_number_rou4A_by_muP,6));
         Assert.AreEqual(1.556579, Math.Round(reynolds_number_roQDH_by_muA, 6));
         Assert.AreEqual(1.556579, Math.Round(reynolds_number_roQ4_by_muP, 6));
         Assert.AreEqual(1.556579, Math.Round(reynolds_number_uDH_by_nu, 6));
         Assert.AreEqual(1.556579, Math.Round(reynolds_number_u4A_by_nuP, 6));
         Assert.AreEqual(1.556579, Math.Round(reynolds_number_QDH_by_nuA, 6));
         Assert.AreEqual(1.556579, Math.Round(reynolds_number_Q4_by_nuP, 6));
      }

      [TestMethod]
      public void TesReynoldsNumberInSquarePipe()
      {
         double ro = 910; // kg / m3
         double u = 2.6; // m / s
         double mu = 0.38; // N s / m2
         double nu = mu / ro; // m / s
         // assuming square pipe and half "wet"
         double side = 0.00025; // m
         double A = Math.Pow(side, 2) / 2; // m2 (half of the area)
         double P = side * 2; // m (half of the perimeter)
         double Q = u * A; // m2 / s

         double reynolds_number_rou4A_by_muP = HydraulicFormulas.ReynoldsNumberInPipe_rou4A_by_muP(ro, u, A, mu, P);
         double reynolds_number_roQ4_by_muP = HydraulicFormulas.ReynoldsNumberInPipe_roQ4_by_muP(ro, Q, mu, P);
         double reynolds_number_u4A_by_nuP = HydraulicFormulas.ReynoldsNumberInPipe_u4A_by_nuP(u, A, nu, P);
         double reynolds_number_Q4_by_nuP = HydraulicFormulas.ReynoldsNumberInPipe_Q4_by_nuP(Q, nu, P);

         Assert.AreEqual(1.556579, Math.Round(reynolds_number_rou4A_by_muP, 6));
         Assert.AreEqual(1.556579, Math.Round(reynolds_number_roQ4_by_muP, 6));
         Assert.AreEqual(1.556579, Math.Round(reynolds_number_u4A_by_nuP, 6));
         Assert.AreEqual(1.556579, Math.Round(reynolds_number_Q4_by_nuP, 6));
      }

   }
}
