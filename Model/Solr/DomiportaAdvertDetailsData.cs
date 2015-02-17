// -----------------------------------------------------------------------
// <copyright file="DomiportaAdvertDetailsData.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Model.Solr
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Json;

    using Newtonsoft.Json;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DomiportaAdvertDetailsData
    {
        public DomiportaAdvertDetailsData()
        {
            Pictures = new List<string>();
        }
        // ------------------------------------------------------- //
        // dane dotyczące ogłoszenia
        // ------------------------------------------------------- //
        public int? Allads_ID { get; set; }
        public string Allads_TraderID { get; set; }
        public int Allads_UserId { get; set; }
        public int Allads_CategoryId { get; set; }
        public string Allads_Path { get; set; }
        public int Allads_Active { get; set; }
        public string Allads_Temat { get; set; }
        public DateTime Allads_InsertIonDate { get; set; }
        public DateTime Allads_BestBefore { get; set; }
        public DateTime Allads_ModifyDate { get; set; }
        public DateTime Allads_SortDate { get; set; }
        public int? Allads_Premium { get; set; }
        public int? Allads_RegionID { get; set; }
        public int? Allads_PayCode { get; set; }
        public string Allads_ZrodloDanych { get; set; }
        public string Allads_ZrodloDanychLogo { get; set; }
        public string Allads_AdType { get; set; }
        public string Allads_Kontakt { get; set; }
        public string Allads_LayoutAccount { get; set; }
        public string Allads_LayoutCode { get; set; }
        public string Allads_ViewInLayouts { get; set; }
        public string Allads_MD5 { get; set; }
        public string Allads_Category { get; set; }
        public decimal? Allads_Cena { get; set; }
        public string Allads_Cena_Currency { get; set; }
        public decimal? Allads_Cena_LocalPrice { get; set; }
        public int Allads_internet { get; set; }
        public string Allads_Miasto { get; set; }
        public int Allads_Nowa { get; set; }
        public int Allads_Oferta_dnia { get; set; }
        public string Allads_Operacja { get; set; }
        public int Allads_PicCnt { get; set; }
        public int? Allads_Picture3D { get; set; }
        public string Allads_powiat { get; set; }
        public int? Allads_PressEmisje { get; set; }
        public string Allads_PressType { get; set; }
        public int Allads_Priv { get; set; }
        public int? Allads_Random { get; set; }
        public string Allads_StaraCena_Currency { get; set; }
        public decimal? Allads_StaraCena_LocalPrice { get; set; }
        public string Allads_status { get; set; }
        public string Allads_UserName { get; set; }
        public int Allads_Wyslane { get; set; }
        public string Allads_Zdjecie1 { get; set; }
        public string Allads_Opis { get; set; }
        public string Allads_AgentId { get; set; }
        public string Allads_AgentString { get; set; }
        public int? Allads_BankOfert { get; set; }
        public decimal? Allads_Cena_m_pklucz { get; set; }
        public string Allads_Cena_m_pklucz_currency { get; set; }
        public decimal? Allads_Cena_m_pklucz_localprice { get; set; }
        public decimal? Allads_Cena_m_standard { get; set; }
        public string Allads_Cena_m_standard_currency { get; set; }
        public decimal? Allads_Cena_m_standard_localprice { get; set; }
        public decimal? Allads_cena_metra { get; set; }
        public string Allads_cena_metra_Currency { get; set; }
        public decimal? Allads_cena_metra_LocalPrice { get; set; }
        public string Allads_Cena_Opis { get; set; }
        public string Allads_CenaOdDo { get; set; }
        public string Allads_Discount { get; set; }
        public decimal? Allads_StaraCena { get; set; }
        public int? Allads_SumaWag { get; set; }
        public string Allads_Name { get; set; }
        public int? Allads_Rocznik { get; set; }
        public string Allads_Typ { get; set; }
        public string Allads_Address { get; set; }
        public decimal? Allads_Cena_pklucz { get; set; }
        public string Allads_Cena_pklucz_currency { get; set; }
        public decimal? Allads_Cena_pklucz_localprice { get; set; }
        public decimal? Allads_Cena_standard { get; set; }
        public string Allads_Cena_standard_currency { get; set; }
        public decimal? Allads_Cena_standard_localprice { get; set; }
        public string Allads_Czy_bocznica { get; set; }
        public int? Allads_czy_mozliwy_podzial { get; set; }
        public string Allads_Czy_ogrzewanie { get; set; }
        public int? Allads_czynsz_najemca { get; set; }
        public string Allads_dach { get; set; }
        public int Allads_Developer { get; set; }
        public int? Allads_domofon { get; set; }
        public decimal? Allads_dopuszczalna_zabudowa { get; set; }
        public string Allads_droga_dojazdowa { get; set; }
        public decimal? Allads_dzialka_powierzchnia { get; set; }
        public string Allads_dzialka_uwagi { get; set; }
        public string Allads_Dzielnica { get; set; }
        public int? Allads_elektr { get; set; }
        public int? Allads_estate_id { get; set; }
        public int Allads_exclusive { get; set; }
        public string Allads_forma_wlasnosci { get; set; }
        public string Allads_forma_wlasnosci_uwagi { get; set; }
        public int? Allads_garaz { get; set; }
        public int? Allads_garaz_liczba_stanowisk { get; set; }
        public string Allads_garaz_typ { get; set; }
        public int? Allads_gaz { get; set; }
        public string Allads_glosnosc { get; set; }
        public string Allads_gmina { get; set; }
        public string Allads_halas { get; set; }
        public string Allads_Informacje_dodatkowe { get; set; }
        public string Allads_InwestycjaID { get; set; }
        public string Allads_InwestycjaPicture { get; set; }
        public string Allads_kanalizacja { get; set; }
        public string Allads_kategoria { get; set; }
        public string Allads_kierunek { get; set; }
        public int? Allads_klimatyzacja { get; set; }
        public string Allads_ksztalt { get; set; }
        public string Allads_kuchnia { get; set; }
        public string Allads_Kuchnia_opis { get; set; }
        public decimal? Allads_kuchnia_powierzchnia { get; set; }
        public string Allads_Lazienka { get; set; }
        public string Allads_Lazienka_Opis { get; set; }
        public int? Allads_lazienka_z_WC { get; set; }
        public int? Allads_liczba_kondygnacji { get; set; }
        public int? Allads_liczba_lazienek { get; set; }
        public int? Allads_Liczba_pieter { get; set; }
        public int? Allads_Liczba_pokoi { get; set; }
        public int? Allads_Liczba_pomieszczen { get; set; }
        public int? Allads_liczba_poziomow { get; set; }
        public int? Allads_liczba_stanowisk_garazowych { get; set; }
        public int? Allads_liczba_stanowisk_parkingowych { get; set; }
        public int? Allads_liczba_stron { get; set; }
        public int? Allads_liczba_sypialni { get; set; }
        public int? Allads_lodowka { get; set; }
        public string Allads_Logo { get; set; }
        public int? Allads_lokal_pusty { get; set; }
        public string Allads_Lokalizacja { get; set; }
        public int? Allads_magazyn_ogrzewany { get; set; }
        public decimal? Allads_magazyn_powierzchnia { get; set; }
        public decimal? Allads_magazyn_wysokosc { get; set; }
        public string Allads_material { get; set; }
        public string Allads_meble { get; set; }
        public string Allads_Media { get; set; }
        public int? Allads_media_elektr { get; set; }
        public int? Allads_media_gaz { get; set; }
        public int? Allads_media_kanalizacja { get; set; }
        public string Allads_Media_opis { get; set; }
        public int? Allads_media_sila { get; set; }
        public int? Allads_media_woda { get; set; }
        public decimal? Allads_moc_pradu { get; set; }
        public string Allads_najblizsza_przecznica { get; set; }
        public string Allads_nawierzchnia_drogi { get; set; }
        public int? Allads_NaWylacznosc { get; set; }
        public string Allads_Nr { get; set; }
        public string Allads_Nr_oferty { get; set; }
        public string Allads_Nr_wew { get; set; }
        public string Allads_numer_domu { get; set; }
        public decimal? Allads_obiekt_pow_calkowita { get; set; }
        public decimal? Allads_obiekt_pow_uzytkowa { get; set; }
        public decimal? Allads_odleglosc_od_centrum_miasta_woj { get; set; }
        public decimal? Allads_odleglosc_od_drogi_glownej { get; set; }
        public int? Allads_ogrodek { get; set; }
        public string Allads_ogrodzenie { get; set; }
        public string Allads_ogrzewanie { get; set; }
        public int? Allads_okablowanie_komputerowe { get; set; }
        public string Allads_Okablowanie_opis { get; set; }
        public int? Allads_okablowanie_strukturalne { get; set; }
        public string Allads_okna_strony_swiata { get; set; }
        public string Allads_Okolica { get; set; }
        public string Allads_Opis_pieter { get; set; }
        public string Allads_opis_pokoje { get; set; }
        public string Allads_opis_pomieszczen { get; set; }
        public string Allads_opis_tech_uwagi { get; set; }
        public string Allads_oplaty_licznikowe { get; set; }
        public string Allads_Oplaty_opis { get; set; }
        public decimal? Allads_oplaty_ryczaltowe { get; set; }
        public string Allads_oplaty_ryczaltowe_opis { get; set; }
        public string Allads_Oswietlenie { get; set; }
        public string Allads_otoczenie { get; set; }
        public string Allads_parking_typ { get; set; }
        public string Allads_Parter { get; set; }
        public string Allads_pietra_opis { get; set; }
        public int? Allads_pietro { get; set; }
        public string Allads_Piwnica { get; set; }
        public decimal? Allads_piwnica_powierzchnia { get; set; }
        public string Allads_poddasze_opis { get; set; }
        public string Allads_podloga { get; set; }
        public string Allads_pokoje_opis { get; set; }
        public string Allads_polozenie { get; set; }
        public decimal? Allads_Pow_biura { get; set; }
        public decimal? Allads_Pow_dzial { get; set; }
        public decimal? Allads_Pow_miesz { get; set; }
        public decimal? Allads_powierzchnia { get; set; }
        public decimal? Allads_powierzchnia_salonu { get; set; }
        public decimal? Allads_powierzchnia_zabudowy { get; set; }
        public string Allads_PowierzchniaOdDo { get; set; }
        public int? Allads_pralka { get; set; }
        public string Allads_przedpokoj_Opis { get; set; }
        public string Allads_przedpokoj_podloga { get; set; }
        public decimal? Allads_przedpokoj_powierzchnia { get; set; }
        public string Allads_przeznaczenie { get; set; }
        public string Allads_przy_drodze { get; set; }
        public int? Allads_rampa { get; set; }
        public string Allads_Rodzaj { get; set; }
        public decimal? Allads_salon_powierzchnia { get; set; }
        public string Allads_sasiedztwo { get; set; }
        public string Allads_sila { get; set; }
        public bool? Allads_spec { get; set; }
        public string Allads_stan_lokalu { get; set; }
        public string Allads_stan_techniczny { get; set; }
        public string Allads_standard { get; set; }
        public int? Allads_strych { get; set; }
        public decimal? Allads_strych_powierzchnia { get; set; }
        public string Allads_technologia { get; set; }
        public int? Allads_Telefon { get; set; }
        public DateTime? Allads_TerminRealizacji { get; set; }
        public string Allads_Tir_dojazd { get; set; }
        public int? Allads_transakcja_wiazana { get; set; }
        public int? Allads_TV { get; set; }
        public int? Allads_TV_kablowa { get; set; }
        public string Allads_Ulica { get; set; }
        public string Allads_Urzadzenia { get; set; }
        public int? Allads_winda { get; set; }
        public int? Allads_witryny { get; set; }
        public string Allads_woda { get; set; }
        public decimal? Allads_wsp_pow_wsp { get; set; }
        public int? Allads_wspolczynnik { get; set; }
        public int? Allads_wymiar_boku_przyleg_do_ulicy { get; set; }
        public string Allads_wymiary { get; set; }
        public string Allads_wymiary_bokow { get; set; }
        public decimal? Allads_wysokosc { get; set; }
        public decimal? Allads_wysokosc_czynszu { get; set; }
        public string Allads_wysokosc_czynszu_Currency { get; set; }
        public decimal? Allads_wysokosc_czynszu_LocalPrice { get; set; }
        public int? Allads_wysokosc_zabudowy { get; set; }
        public string Allads_zabezpieczenia { get; set; }
        public string Allads_zagospodarowanie { get; set; }
        public int? Allads_zalesienie { get; set; }
        public int? Allads_zamrazarka { get; set; }
        public int? Allads_zmywarka { get; set; }
        public string Allads_zsyp { get; set; }
        public string Allads_ImportProcedure { get; set; }
        public int? Allads_Liczba_miejsc { get; set; }
        public string Allads_sponsoring { get; set; }
        public decimal? Allads_powierzchnia_minimalna { get; set; }
        public string Allads_Umiejscowienie { get; set; }
        public string Allads_ImportFileName { get; set; }
        public int? Allads_isLux { get; set; }
        public int? Allads_geokodx { get; set; }
        public int? Allads_geokody { get; set; }
        public int? Allads_isGeokoded { get; set; }
        public string Allads_KrotkiOpis { get; set; }
        public string Allads_agent { get; set; }
        public string Allads_nr_licencji { get; set; }
        public string Allads_video { get; set; }
        public string Allads_dodatkowy_opis { get; set; }
        public string Allads_geoOptions { get; set; }
        // ------------------------------------------------------- //
        // dane dotyczące zdjęć
        // ------------------------------------------------------- //
        public List<string> Pictures { get; set; }
        // ------------------------------------------------------- //
        // dane usera
        // ------------------------------------------------------- //

        public string UsersLogo { get; set; }

        public string UsersName { get; set; }

        public string UsersType { get; set; }

        public string UsersStatus { get; set; }

        public string UsersEmail { get; set; }

        public string UsersAddress { get; set; }

        public string UsersZipCode { get; set; }

        public string UsersCity { get; set; }

        public int? UsersRegionId { get; set; }

        public string UsersRegionName { get; set; }

        public string UsersCountry { get; set; }

        public string UsersTelefax { get; set; }

        public string UsersFirstPhone { get; set; }

        public string UsersSecondPhone { get; set; }

        public string UsersMobilPhone { get; set; }

        public bool? DontShowPrice { get; set; }

        // ------------------------------------------------------- //
        // serializacja i deserializacja
        // ------------------------------------------------------- //

        public string Serialize()
        {
            var ser = new DataContractJsonSerializer(typeof(DomiportaAdvertDetailsData));

            using (var ms = new MemoryStream())
            {
                using (var reader = new StreamReader(ms))
                {
                    ser.WriteObject(ms, this);
                    ms.Seek(0, 0);
                    return reader.ReadToEnd();
                }
            }
        }

        public static DomiportaAdvertDetailsData Deserialize(string s)
        {
            return JsonConvert.DeserializeObject<DomiportaAdvertDetailsData>(s);
        }
    }
}
