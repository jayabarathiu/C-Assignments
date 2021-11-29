using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineDrive
{
    class VaccineProject
    {
        static VaccineProject VaccineMain = new VaccineProject();
        static List<Benificiery> BeficicieryObj = new List<Benificiery>();
        Vaccine VaccineObj = new Vaccine();
        static void Main(string[] args)
        {
            
            var Detail = new Benificiery("XXXX",30,"chenai",Gender.MALE,76534695);
            var Detail1 = new Benificiery("YYYY", 40, "Cudalore", Gender.FEMALE, 1347346857);
            BeficicieryObj.Add(Detail);
            BeficicieryObj.Add(Detail1);
            bool FirstDo = false;
            int MainChoice;
            string choice;
            do
            {
                Console.WriteLine("Vaccination Portal");
                Console.WriteLine("\n1.Beneficiery Registration \n1.Vaccination  \n 3. Exit ");
                MainChoice = int.Parse(Console.ReadLine());
                switch (MainChoice)
                {
                    case 1:
                        VaccineMain.BenificieryRegistration();
                        break;
                    case 2:
                        VaccineMain.Vaccination();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("enter invalid input");
                        break;

                }
                Console.WriteLine("Do you want continue Yes / No?");
                choice = Console.ReadLine().ToUpper();

                FirstDo = false;
                if (choice == opt.YES.ToString())
                {
                    FirstDo= true;
                }

            } while (FirstDo == true);



        }
        public void BenificieryRegistration()
        {
            string RegName, RegCity;
            Gender RegGender;
            int RegAge,GenderOption,temp;
            long RegPhno;
            Console.WriteLine("Enter  Name : ");
            RegName = Console.ReadLine();
            Console.WriteLine("Enter  Age");
            RegAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your City : ");
            RegCity = Console.ReadLine();
            Console.WriteLine("Enter PhoneNumber : ");
            RegPhno = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Gender 1. Male 2.Female \n 3.Transgender  : ");
            GenderOption = int.Parse(Console.ReadLine());
            if (GenderOption == 1)
            {
                RegGender =Gender.MALE;
                var Detail3 = new Benificiery(RegName, RegAge, RegCity, RegGender, RegPhno);

                BeficicieryObj.Add(Detail3);

            }
            else if (GenderOption == 2)
            {
                RegGender = Gender.FEMALE;
                var Detail3 = new Benificiery(RegName, RegAge, RegCity, RegGender, RegPhno);

                BeficicieryObj.Add(Detail3);
            }
             else if (GenderOption == 3)
            {
                RegGender = Gender.TRANSGENDER;
                var Detail3 = new Benificiery(RegName, RegAge, RegCity, RegGender, RegPhno);

                BeficicieryObj.Add(Detail3);
            }
            
            foreach(Benificiery dt in BeficicieryObj)
            {
                if (dt.Name == RegName)
                {
                    temp=dt.RegNo;
                    Console.WriteLine($"Hi {RegName}, successfully Registered: {temp}  ");
                }
            }
        }
        public void Vaccination()
        {
            VaccineType typ;
        int RegId,UserChoice;
            Console.WriteLine(" Enter Registration ID:");
            RegId = int.Parse(Console.ReadLine());
            foreach (Benificiery dt in BeficicieryObj)
            {
                if (dt.RegNo== RegId)
                {
                    Console.WriteLine("Enter  Choice: \nTake Vaccination -> 1\nVaccination History -> 2\nNext due Date ->3\n EXit->4");
                    UserChoice = int.Parse(Console.ReadLine());
                    switch (UserChoice)
                    {
                        case 1:
                            Console.WriteLine("Enter Choice \n 1. Covishield \n2. Covaxin ");
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 1)
                            {
                                Console.WriteLine("Dose 1 or 2?");
                                int dosel = int.Parse(Console.ReadLine());
                                if (dosel == 1)
                                {
                                    typ = VaccineType.Covishield;
                                    VaccineObj.Dosage = "Dose1";

                                    dt.VaccinationDetail(dt.RegNo, dt.Name, dt.Age, dt.City, dt.gender, dt.PhNo,typ, VaccineObj.Dosage);
                                }
                                else if (dosel == 2)
                                {
                                    typ = VaccineType.Covaxin;
                                    VaccineObj.Dosage = "Dose2";
                                    dt.VaccinationDetail(dt.RegNo, dt.Name, dt.Age, dt.City, dt.gender, dt.PhNo, typ, VaccineObj.Dosage);
                                }
                                else
                                {

                                    Console.WriteLine("INVALID");
                                }
                            }
                            else
                            {
                                Console.WriteLine("dose 1 or 2?");
                                int dosel = int.Parse(Console.ReadLine());
                                if (dosel == 1)
                                {
                                    typ = VaccineType.Covaxin;
                                    VaccineObj.Dosage = "Dose1";

                                    dt.VaccinationDetail(dt.RegNo, dt.Name, dt.Age, dt.City, dt.gender, dt.PhNo, typ, VaccineObj.Dosage);
                                }
                                else if (dosel == 2)
                                {
                                    typ = VaccineType.Covaxin;
                                    VaccineObj.Dosage = "Dose2";
                                }
                                else
                                {
                                    Console.WriteLine("INVALID");
                                }

                            }
                                                     
                            break;
                        case 2:
                            dt.VaccinationHistory(dt.RegNo, dt.Name, dt.Age, dt.City, dt.gender, dt.PhNo);

                            break;
                        case 3:
                            dt.NextDueDate(dt.RegNo, dt.Name);

                            break;
                        case 4:
                            
                            break;
                        default:
                            Console.WriteLine("INVALID CHOICE");
                            break;

                    }
                   
                    
                }
            }

        }
    }

    
    public enum opt
    {
        YES,
        NO
    }
    public enum Gender
    {
        MALE,
        FEMALE,
        TRANSGENDER
    }
}
