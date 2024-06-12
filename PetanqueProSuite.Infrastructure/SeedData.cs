using Microsoft.EntityFrameworkCore;
using PetanqueProSuite.Domain;
using PetanqueProSuite.Domain.Competition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace PetanqueProSuite.Infrastructure
{
    public class SeedData
    {
        private readonly PetanqueProSuiteDbContext dbContext;
        public SeedData(PetanqueProSuiteDbContext context)
        {
            dbContext = context;
        }

        public void Initialize()
        {
            dbContext.Database.EnsureCreated();

            Category vet = new Category { Name = "Veteran" };
            Category sen = new Category { Name = "Senior" };
            Category wom = new Category { Name = "Women" };

            if (!dbContext.Categories.Any())
            {
                dbContext.Categories.AddRange(new List<Category>() { vet, sen, wom });
            }


            League natSen = new League { Name = "National", Category = sen };

            League fedSen = new League { Name = "Federal", Category = sen };
            League fedWom = new League { Name = "Federal", Category = wom };

            League provLimSen = new League { Name = "Provincial (Limburg)", Category = sen };
            League provAntSen = new League { Name = "Provincial (Antwerp)", Category = sen };

            League provLimVet = new League { Name = "Provincial (Limburg)", Category = vet };
            League provAntVet = new League { Name = "Provincial (Antwerp)", Category = vet };

            if (!dbContext.Leagues.Any())
            {
                dbContext.Leagues.AddRange(new List<League>() { natSen, fedSen, fedWom, provLimSen, provAntSen, provLimVet, provAntVet });
            }


            Division nat1st = new Division { Name = "1st National", League = natSen };
            Division nat2nd = new Division { Name = "2nd National", League = natSen };

            Division fed1stSen = new Division { Name = "1st Federal", League = fedSen };
            Division fed2ndSen = new Division { Name = "2nd Federal", League = fedSen };
            Division fed1stWom = new Division { Name = "1st Federal", League = fedWom };

            Division provEreSen = new Division { Name = "Ere Division", League = provLimSen };
            Division prov1stSen = new Division { Name = "1st Division", League = provLimSen };

            Division provEreVet = new Division { Name = "Ere Division", League = provLimVet };
            Division prov1stVet = new Division { Name = "1st Division", League = provLimVet };
            Division prov2ndVet = new Division { Name = "2nd Division", League = provLimVet };

            if (!dbContext.Divisions.Any())
            {
                dbContext.Divisions.AddRange(new List<Division>() { nat1st, nat2nd, fed1stSen, fed2ndSen, fed1stWom, provEreSen, prov1stSen, provEreVet, prov1stVet, prov2ndVet });
            }

            Federation PFV = new Federation { Name = "Petanque Federatie Vlaanderen" };

            if (!dbContext.Federations.Any())
            {
                dbContext.Federations.Add(PFV);
            }

            Province OostVlaanderen = new Province { Name = "Oost-Vlaanderen", Federation = PFV};
            Province Antwerpen = new Province { Name = "Antwerpen", Federation = PFV };
            Province Limburg = new Province { Name = "Limburg", Federation = PFV };
            Province VlaamsBrabant = new Province { Name = "Vlaams Brabant", Federation = PFV };
            Province WestVlaanderen = new Province { Name = "West-Vlaanderen", Federation = PFV };

            if (!dbContext.Provinces.Any())
            {
                dbContext.Provinces.AddRange(new List<Province>() { OostVlaanderen, Antwerpen, Limburg, VlaamsBrabant, WestVlaanderen });
            }

            // Limburg
            Club OLYMPIA = new Club { Name = "PC OLYMPIA", Number = 1, Address = "Veenderweg 48 - 3550 Heusden-Zolder", Phone = "011/45 36 13", ContactPerson = "Ferdy Geraerts, Ubbelstraat 9/1 - 3550 Heusden-Zolder", Province = Limburg };
            Club SPARRENDAL = new Club { Name = "PC SPARRENDAL", Number = 2, Address = "Roelerdreef 17 - 3620 Lanaken", Phone = "GSM: 0476052765", ContactPerson = "De Haan Irene, GSM: 0477 654 089, Email: schepers.poels@gmail.com", Province = Limburg };
            Club KELCHTEREN = new Club { Name = "PC KELCHTEREN - HOUTHALEN", Number = 3, Address = "Oudstrijderslaan 44C - 3530 Houthalen", ContactPerson = "Chris Billen Guldensporenlaan 28 3530 Houthalen, Email: pckelchtren.houthalen@hotmail.com", Province = Limburg };
            Club HASSELT = new Club { Name = "PC HASSELT", Number = 4, Address = "Kramerslaan 1A - 3500 Hasselt", Phone = "011/27 30 36", ContactPerson = "Jan Luyten, GSM : 0479/73 75 47, Email : luytenfabbro@gmail.com", Province = Limburg };
            Club OPEC = new Club { Name = "PC OPEC OPGLABBEEK", Number = 6, Address = "Oude Kerkstraat 24B - 3660 Opglabbeek", ContactPerson = "Raymond Brebels, GSM : 0478/71 22 54, Email : raymond.brebels@telenet.be", Province = Limburg };
            Club BOEKT = new Club { Name = "PC BOEKT", Number = 7, Address = "Ubbelstraat 97 - 3550 Heusden-Zolder", Phone = "0492/79 15 48", ContactPerson = "Ludo Daniels, GSM : 0492/79 15 48, Email : ludodaniels@skynet.be", Province = Limburg };
            Club GENENBOS = new Club { Name = "PC GENENBOS", Number = 8, Address = "Boskesstraat 1 - 3560 Lummen", ContactPerson = "Benny Claes, Nieuwstraat 21 - 3560 Lummen, GSM : 0498/11 94 11, Email : bennyclaespcgenenbos@hotmail.com", Province = Limburg };
            Club BERK = new Club { Name = "PC DE BERK", Number = 9, Address = "Valentinusstraat 50 - 3550 Heusden-Zolder", Phone = "011/81 13 25", ContactPerson = "Eric Mignon Wolfsdal 50 3530 Houthalen-Helchteren, GSM: 0474/27 52 71, Email : pcdeberk@gmail.com", Province = Limburg };
            Club ZIG = new Club { Name = "PC ZIG ZAG", Number = 11, Address = "Bivakstraat - 3945 Ham", Phone = "GSM: 0499/30 87 91", ContactPerson = "André Reynders, Zillekesstraat 8 - 3980 Tessenderlo, Tel: 013/66 65 53 - GSM: 0496/20 61 68, Email : reynders.andre@hotmail.com", Province = Limburg };
            Club PELTER = new Club { Name = "PELTER PC", Number = 12, Address = "Sportpark De Roosen 43 - 3910 Neerpelt", Phone = "011/80 22 49", ContactPerson = "Elly Jamers Holwortelstraat 14 3900 Pelt, GSM: 0495/454 777, Email : elly.jamers@skynet.be", Province = Limburg };
            Club HORIZON = new Club { Name = "PC HORIZON - BREE", Number = 13, Address = "Opitterpoort 104 - 3960 Bree", ContactPerson = "Gos Willy, Pater Lambertusstraat 18 Bus 03 - 3960 Bree, GSM: 0486/965197, Email : gos.vandereecken@telenet.be", Province = Limburg };
            Club GENK = new Club { Name = "PC GENK", Number = 14, Address = "Melbergstraat 1B2 - 3600 Genk", ContactPerson = "Marlene Hendrikx Zandstraat 5 3665 As, GSM: 0474/57 14 29, Emai: meenske053@gmail.com", Province = Limburg };
            Club TONGEREN = new Club { Name = "PC 13 TONGEREN", Number = 15, Address = "Bilzersteenweg 36a - 3700 Tongeren", ContactPerson = "Josianne Fastre, Email : josyfastre61@gmail.com", Province = Limburg };
            Club INTERLOMMEL = new Club { Name = "INTERLOMMEL PETANQUE", Number = 20, Address = "Vreyshorring 143 - 3920 Lommel", Phone = "011/54 57 43", ContactPerson = "Annita Serroeyen, GSM: 0475/43 24 65, Email : verboven-serroeyen@hotmail.com", Province = Limburg };
            Club OETERVALLEI = new Club { Name = "PC OETERVALLEI", Number = 21, Address = "Opitterpoort 104 - 3960 Bree", ContactPerson = "Maurissen Ivo, Voorschoventerweg 96 - 3680 Neeroeteren, GSM: 0477/853173, Email : ivo.maurissen@gmail.com", Province = Limburg };
            Club MELDERT = new Club { Name = "PC MELDERT", Number = 22, Address = "Zelemsebaan 50 - 3560 Lummen", Phone = "013/33 52 06", ContactPerson = "Cyriel Schepers, Zelemsebaan 50 - 3560 Lummen, Email : schepers.cyriel@telenet.be", Province = Limburg };
            Club SINT = new Club { Name = "PC SINT-TRUIDEN", Number = 23, Address = "Staeyen Oosttribune, Tiensesteenweg 168 - 3800 Sint-Truiden", ContactPerson = "Tits Danny, Gorsem-Dorp 91 - 3800 Sint-Truiden, Email : pcsttruiden@gmail.com", Province = Limburg };
            Club MAASEIK = new Club { Name = "PC MAASEIK", Number = 24, Address = "Koningin Astridlaan 91 - 3680 Maaseik", ContactPerson = "Aerts Agnes, Wurfelderweg 79 - 3680 Maaseik, Tel : 089/56 78 73, Email : aertsanjes@skynet.be", Province = Limburg };
            Club TERBIEST = new Club { Name = "PC TERBIEST", Number = 28, Address = "Hasseltsesteenweg 103 - 3800 Sint-Truiden", ContactPerson = "Jules Bonneux, GSM : 0485/98 40 14, Email: jules.bonneux@hotmail.com", Province = Limburg };
            Club VENNE = new Club { Name = "PC DE VENNE", Number = 29, Address = "Hurbroekstraat - 3540 Herk-de-Stad", ContactPerson = "Blokken Willy , Dreefstraat 23 - 3540 Herk-de-Stad, GSM: 0478/543603, Email: willy.blokken@telenet.be", Province = Limburg };
            Club BOCHOLTER = new Club { Name = "BOCHOLTER PETANQUE", Number = 30, Address = "Eikenlaan z/n - 3950 Bocholt", ContactPerson = "De Grood Henri, Zandstraat 5 - 3950 Bocholt, GSM: 0486/965 197, Email : secretaris@bocholterpetanque.be", Province = Limburg };
            Club FENIX = new Club { Name = "PC FENIX", Number = 32, Address = "Hasseltsesteenweg 103- 3800 Sint-Truiden", ContactPerson = "Lelievre Stefaan,Erberstraat 25-3800 Sint-Truiden, GSM: 0496/510584, Email: Petanqueclubfenix@gmail.com", Province = Limburg };
            Club Yachting = new Club { Name = "PC Royal Hasselt Yachting Club", Number = 33, Address = "Hoogbrugkaai 91 - 3500 Hasselt", ContactPerson = "Danny Vanderstraeten - Luikersteenweg 248B 4/2 - 3500 Hasselt, Gsm: 0496/61 89 32, Tel: 011/21 25 70, Emailadres: info@rhyc.be", Province = Limburg };

            if (!dbContext.Clubs.Any())
            {
                dbContext.Clubs.AddRange(new List<Club>() { OLYMPIA, SPARRENDAL, KELCHTEREN, HASSELT, OPEC, BOEKT, GENENBOS, BERK, ZIG, PELTER, HORIZON, GENK, TONGEREN, INTERLOMMEL, OETERVALLEI, MELDERT, SINT, MAASEIK, TERBIEST, VENNE, BOCHOLTER, FENIX, Yachting });
            }

            License p1BoektEre = new License { Club = BOEKT, FirstName = "Rony", LastName = "Bleux", Number = 10000 };
            License p2BoektEre = new License { Club = BOEKT, FirstName = "Frans", LastName = "Kazmierczak", Number = 4077 };
            License p3BoektEre = new License { Club = BOEKT, FirstName = "Jose", LastName = "xqwer", Number = 99990 };
            License p4BoektEre = new License { Club = BOEKT, FirstName = "Serano", LastName = "xqty", Number = 12345 };
            License p5BoektEre = new License { Club = BOEKT, FirstName = "Toto", LastName = "dfghx", Number = 65432 };
            License p6BoektEre = new License { Club = BOEKT, FirstName = "Eric", LastName = "xop", Number = 27898 };
            License p7BoektEre = new License { Club = BOEKT, FirstName = "Steven", LastName = "Kazmierczak", Number = 99871 };
            License p8BoektEre = new License { Club = BOEKT, FirstName = "Tonny", LastName = "lkl", Number = 9814 };
            License p9BoektEre = new License { Club = BOEKT, FirstName = "Mario", LastName = "vcx", Number = 658 };
            License p10BoektEre = new License { Club = BOEKT, FirstName = "Lina", LastName = "qqwx", Number =  5475 };

            if (!dbContext.Licenses.Any())
            {
                dbContext.Licenses.AddRange(new List<License>() { p1BoektEre, p2BoektEre, p3BoektEre, p4BoektEre, p5BoektEre, p6BoektEre, p7BoektEre, p8BoektEre, p9BoektEre, p10BoektEre });
            }

            //CompetitionTeam boektA = new CompetitionTeam { Identifyer = 'A', Club = BOEKT, Division = provEreSen };
            //CompetitionTeam OpecA = new CompetitionTeam { Identifyer = 'A', Club = OPEC, Division = provEreSen };
            //CompetitionTeam boektB = new CompetitionTeam { Identifyer = 'B', Club = BOEKT, Division = prov1stSen };
            //CompetitionTeam oeterA = new CompetitionTeam { Identifyer = 'A', Club = OETERVALLEI, Division = prov1stSen };
            //CompetitionTeam boektFed = new CompetitionTeam { Club = BOEKT, Division = fed1stSen };
            //CompetitionTeam zigFed = new CompetitionTeam { Club = ZIG, Division = fed1stSen };
            //CompetitionTeam boektNat = new CompetitionTeam { Club = BOEKT, Division = nat1st };
            //CompetitionTeam olyNat = new CompetitionTeam { Club = OLYMPIA, Division = nat1st };

            //if (!dbContext.CompetitionTeams.Any())
            //{
            //    dbContext.CompetitionTeams.AddRange(new List<CompetitionTeam>() { boektA, OpecA, boektB, oeterA, boektFed, zigFed, boektNat, olyNat });
            //}

            dbContext.SaveChanges();
        }
    }
}
