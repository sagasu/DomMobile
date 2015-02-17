// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SolrAdvert.cs" company="">
//   
// </copyright>
// <summary>
//   Klasa przechowującą płaską strukturę adverta domiportowego przeznaczona głównie do komunikacji z SOLR.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Trader.Solr
{
    using System;

    using SolrNet.Attributes;

    using Trader.Model.Solr;

    /// <summary>
    /// Klasa przechowującą płaską strukturę adverta domiportowego przeznaczona głównie do komunikacji z SOLR.
    /// </summary>
    public class SolrAdvert : ISolrOrderByFields, ISolrAdvert
    {
        public SolrAdvert()
        {
            privAdvertData = null;
        }

        /// <summary>
        ///   Gets or sets Id -  odpowiednik pola Id z allads - id ogłoszenia.
        /// </summary>
        [SolrUniqueKey("Id")]
        public virtual int Id { get; set; }

        /// <summary>
        ///   Gets or sets UserId -  odpowiednik pola UserId z allads - Id usera który jest właścicielem ogłoszenia.
        /// </summary>
        [SolrField("UserId")]
        public virtual int UserId { get; set; }

        /// <summary>
        ///   Gets or sets UserName -  odpowiednik pola Name z Users.
        /// </summary>
        [SolrField("UserName")]
        public virtual string UserName { get; set; }

        /// <summary>
        ///   Gets or sets UserType -  odpowiednik pola Type z Users.
        /// </summary>
        [SolrField("UserType")]
        public virtual string UserType { get; set; }

        /// <summary>
        ///   Gets or sets UserStatus -  odpowiednik pola Status z Users.
        /// </summary>
        [SolrField("UserStatus")]
        public virtual string UserStatus { get; set; }

        /// <summary>
        ///   Gets or sets UserLogo -  odpowiednik pola Logo z Users.
        /// </summary>
        [SolrField("UserLogo")]
        public virtual string UserLogo { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether HasUserLogo.
        /// </summary>
        [SolrField("HasUserLogo")]
        public virtual bool HasUserLogo { get; set; }

        /// <summary>
        ///   Gets or sets Active -  odpowiednik pola Active z allads.
        /// </summary>
        [SolrField("Active")]
        public virtual int Active { get; set; }

        /// <summary>
        ///   Gets or sets Premium -  odpowiednik pola Premium z allads.
        /// </summary>
        [SolrField("Premium")]
        public virtual int Premium { get; set; }

        /// <summary>
        ///   Gets or sets CategoryId -  odpowiednik pola CategoryId z allads.
        /// </summary>
        [SolrField("CategoryId")]
        public virtual int CategoryId { get; set; }

        /// <summary>
        ///   Gets or sets CategoryPath -  odpowiednik pola Path z allads.
        /// </summary>
        [SolrField("CategoryPath")]
        public virtual string CategoryPath { get; set; }

        /// <summary>
        ///   Gets or sets InsertionDate -  odpowiednik pola InsertionDate z allads.
        /// </summary>
        [SolrField("InsertionDate")]
        public virtual DateTime InsertionDate { get; set; }

        /// <summary>
        ///   Gets or sets SortDate -  odpowiednik pola SortDate z allads.
        /// </summary>
        [SolrField("SortDate")]
        public virtual DateTime SortDate { get; set; }

        /// <summary>
        ///   Gets or sets Subject -  odpowiednik pola Temat z allads.
        /// </summary>
        [SolrField("Subject")]
        public virtual string Subject { get; set; }

        /// <summary>
        ///   Gets or sets Name -  odpowiednik pola Name z allads.
        /// </summary>
        [SolrField("Name")]
        public virtual string Name { get; set; }

        /// <summary>
        ///   Gets or sets Picture.
        /// </summary>
        [SolrField("Picture")]
        public virtual string Picture { get; set; }

        /// <summary>
        ///   Gets or sets PictureCount.
        /// </summary>
        [SolrField("PictureCount")]
        public virtual int PictureCount { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether is this has Picture
        /// </summary>
        [SolrField("HasPicture")]
        public virtual bool HasPicture { get; set; }


        /// <summary>
        ///   Gets or sets Video.
        /// </summary>
        [SolrField("Video")]
        public virtual string Video { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether is this has Video.
        /// </summary>
        [SolrField("HasVideo")]
        public virtual bool HasVideo { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether is it ExclusiveOffer.
        /// </summary>
        [SolrField("ExclusiveOffer")]
        public virtual bool ExclusiveOffer { get; set; }

        /// <summary>
        ///   Gets or sets LocalPrice -  odpowiednik pola cena_LocalPrice z allads - cena wyrażona w złotówkach.
        /// </summary>
        [SolrField("LocalPrice")]
        public virtual decimal? LocalPrice { get; set; }

        /// <summary>
        ///   Gets or sets SortFactor -  odpowiednik pola SumaWag z allads - istotny element zwiazany z sortowaniem jest tum większy im lepiej jest opisane ogłoszenie.
        /// </summary>
        [SolrField("SortFactor")]
        public virtual int SortFactor { get; set; }

        /// <summary>
        ///   Gets or sets TransactionType -  odpowiednik pola TRN z allads - 1: kupię 2: sprzedam 3: wynajmę.
        /// </summary>
        [SolrField("TransactionType")]
        public virtual int TransactionType { get; set; }

        /// <summary>
        ///   Gets or sets Region -  odpowiednik pola Region z allads ale w postaci stringowj - patrz dictRegions.
        /// </summary>
        [SolrField("Region")]
        public virtual string Region { get; set; }

        /// <summary>
        ///   Gets or sets District -  odpowiednik pola Powiat z allads.
        /// </summary>
        [SolrField("District")]
        public virtual string District { get; set; }

        /// <summary>
        ///   Gets or sets City -  odpowiednik pola Miasto z allads.
        /// </summary>
        [SolrField("City")]
        public virtual string City { get; set; }

        /// <summary>
        ///   Gets or sets Quarter -  odpowiednik pola Dzielnica z allads.
        /// </summary>
        [SolrField("Quarter")]
        public virtual string Quarter { get; set; }

        /// <summary>
        ///   Gets or sets Street -  odpowiednik pola Ulica z allads.
        /// </summary>
        [SolrField("Street")]
        public virtual string Street { get; set; }

        /// <summary>
        ///   Gets or sets GeoCodesLongtitude - zmienna geolokalizacyjna dla google maps przechowująca długość geograficzną.
        /// </summary>
        [SolrField("GeoCodesLongtitude")]
        public virtual decimal? GeoCodesLongtitude { get; set; }

        /// <summary>
        ///   Gets or sets GeoCodesLatitude - zmienna geolokalizacyjna dla google maps przechowująca szerokość geograficzną.
        /// </summary>
        [SolrField("GeoCodesLatitude")]
        public virtual decimal? GeoCodesLatitude { get; set; }

        /// <summary>
        ///   Gets or sets Status - dostępne = 0, zarezerwowane = 1, sprzedane = 2.
        /// </summary>
        [SolrField("Status")]
        public virtual byte Status { get; set; }

        /// <summary>
        ///   Gets or sets PropertyType - odpowiednik pola Typ z allads.
        /// </summary>
        [SolrField("PropertyType")]
        public virtual string PropertyType { get; set; }

        /// <summary>
        ///   Gets or sets PropertyType - odpowiednik pola ZrodloDanych z allads.
        /// </summary>
        [SolrField("SourceDataKind")]
        public virtual string SourceDataKind { get; set; }

        /// <summary>
        ///   Gets or sets PropertyType - odpowiednik pola ZrodloDanychLogo z allads.
        /// </summary>
        [SolrField("SourceDataLogo")]
        public virtual string SourceDataLogo { get; set; }

        /// <summary>
        ///   Gets or sets PropertyType - odpowiednik pola Kanalizacja z allads.
        /// </summary>
        [SolrField("Sewerage")]
        public virtual string Sewerage { get; set; }

        /// <summary>
        ///   Gets or sets PropertyType - odpowiednik pola Media z allads.
        /// </summary>
        [SolrField("Media")]
        public virtual string Media { get; set; }

        /// <summary>
        ///   Gets or sets Kind - odpowiednik pola Rodzaj z allads.
        /// </summary>
        [SolrField("Kind")]
        public virtual string Kind { get; set; }

        /// <summary>
        ///   Gets or sets Description - odpowiednik pola Opis.
        /// </summary>
        [SolrField("Description")]
        public virtual string Description { get; set; }

        /// <summary>
        ///   Gets or sets Description - odpowiednik pola Przeznaczenie.
        /// </summary>
        [SolrField("PropertyUsage")]
        public virtual string PropertyUsage { get; set; }

        /// <summary>
        ///   Gets or sets CommissionDate - odpowiednik pola TerminRealizacji.
        /// </summary>
        [SolrField("CommissionDate")]
        public virtual DateTime? CommissionDate { get; set; }

        /// <summary>
        ///   Gets or sets ContactData - odpowiednik pola Kontakt z allads i doklejone dane z tabelki users.
        /// </summary>
        [SolrField("ContactData")]
        public virtual string ContactData { get; set; }

        /// <summary>
        ///   Gets or sets PropertyCateory - odpowiednik pola Kategoria z allads.
        /// </summary>
        [SolrField("PropertyCateory")]
        public virtual string PropertyCateory { get; set; }

        /// <summary>
        ///   Gets or sets SqMetAreal - odpowiednik pola Powierzchnia z allads.
        /// </summary>
        [SolrField("SqMetAreal")]
        public virtual int? SqMetAreal { get; set; }

        /// <summary>
        ///   Gets or sets InvestmentId - odpowiednik pola inwestycjaid z allads - szukane pole Inwestycja.
        /// </summary>
        [SolrField("InvestmentId")]
        public virtual string InvestmentId { get; set; }

        /// <summary>
        ///   Gets or sets InvestmentPicture - odpowiednik pola inwestycjapicture z allads.
        /// </summary>
        [SolrField("InvestmentPicture")]
        public virtual string InvestmentPicture { get; set; }

        /// <summary>
        ///   Gets or sets Year - odpowiednik Rok.
        /// </summary>
        [SolrField("Year")]
        public virtual int? Year { get; set; }

        /// <summary>
        ///   Gets or sets LevelsCount - odpowiednik liczba_kondygnacji.
        /// </summary>
        [SolrField("LevelsCount")]
        public virtual int? LevelsCount { get; set; }

        /// <summary>
        ///   Gets or sets FloorsCount - odpowiednik Liczba_pieter.
        /// </summary>
        [SolrField("FloorsCount")]
        public virtual int? FloorsCount { get; set; }

        /// <summary>
        ///   Gets or sets FloorNum - odpowiednik Pietro.
        /// </summary>
        [SolrField("FloorNum")]
        public virtual int? FloorNum { get; set; }

        /// <summary>
        ///   Gets or sets RoomsCount - odpowiednik Liczba_pokoi.
        /// </summary>
        [SolrField("RoomsCount")]
        public virtual int? RoomsCount { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether IsPrivate - dpowiednik priv.
        /// </summary>
        [SolrField("IsPrivate")]
        public virtual bool IsPrivate { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether IsDeveloper - dpowiednik Developer.
        /// </summary>
        [SolrField("IsDeveloper")]
        public virtual bool IsDeveloper { get; set; }

        /// <summary>
        /// Gets or sets OfferNumber - odpowiednik nr_oferty.
        /// </summary>
        [SolrField("OfferNumber")]
        public virtual string OfferNumber { get; set; }

        /// <summary>
        ///   Gets or sets SqMetLivingAreal - odpowiednik pola Pow_miesz z allads.
        /// </summary>
        [SolrField("SqMetLivingAreal")]
        public virtual int? SqMetLivingAreal { get; set; }

        /// <summary>
        ///   Gets or sets SqMetParcelAreal - odpowiednik pola dzialka_powierzchnia, pow_dzial z allads.
        /// </summary>
        [SolrField("SqMetParcelAreal")]
        public virtual decimal? SqMetParcelAreal { get; set; }

        /// <summary>
        ///   Gets or sets ChambersCount - odpowiednik pola Liczba_pomieszczen z allads.
        /// </summary>
        [SolrField("ChambersCount")]
        public virtual int? ChambersCount { get; set; }

        /// <summary>
        ///   Gets or sets Random - odpowiednik pola Random z allads.
        /// </summary>
        [SolrField("Random")]
        public virtual int? Random { get; set; }

        /// <summary>
        ///   Gets or sets SqMetPrice - odpowiednik pola Cena_metra z allads.
        /// </summary>
        [SolrField("SqMetPrice")]
        public virtual decimal? SqMetPrice { get; set; }

        /// <summary>
        ///   Gets or sets ConcatenatedAdvert - wylicza zlepione pola.
        /// </summary>
        [SolrField("ConcatenatedAdvert")]
        public virtual string ConcatenatedAdvert
        {
            get
            {
                var x = this.City + " ";
                x += this.Street + " ";
                x += this.Subject + " ";
                x += this.PropertyCateory + " ";
                x += this.PropertyType + " ";
                x += this.ContactData + " ";
                x += this.Description + " ";
                x += this.District + " ";
                x += this.Kind + " ";
                x += this.OfferNumber + " ";
                x += this.Quarter + " ";
                x += this.Region + " ";
                x += this.Media + " ";
                x += this.Sewerage + " ";
                x += this.PropertyUsage;
                return x;
            }

            set
            {
            }
        }

        /// <summary>
        /// Gets or sets RecordVer.
        /// </summary>
        [SolrField("RecordVer")]
        public virtual string RecordVer { get; set; }

        /// <summary>
        /// Gets or sets Rynek.
        /// </summary>
        [SolrField("Rynek")]
        public virtual string Rynek { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsSelled.
        /// </summary>
        [SolrField("IsSelled")]
        public virtual bool IsSelled { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether IsSelled.
        /// </summary>
        [SolrField("InvestmentGroupField")]
        public virtual string InvestmentGroupField { get; set; }

        private string privSerializedAdvertData;

        [SolrField("SerializedAdvertData")]
        public virtual string SerializedAdvertData
        {
            get
            {
                return this.privSerializedAdvertData;
            }

            set
            {
                this.privSerializedAdvertData = value;
                if (!string.IsNullOrEmpty(this.privSerializedAdvertData))
                {
                    this.privAdvertData = DomiportaAdvertDetailsData.Deserialize(this.privSerializedAdvertData);
                }
                else
                {
                    this.privAdvertData = null;
                }
            }
        }

        private DomiportaAdvertDetailsData privAdvertData { get; set; }

        public virtual DomiportaAdvertDetailsData AdvertData
        {
            get
            {
                return this.privAdvertData;
            }
        }

        /*
            -- TotalSearch - szukanie po kilku polach 
            Inwestor - // pole do szukania po UserId
            maxID - kryterium szukania po id ogłoszenia
         * page - kryterium szukania po stronie wyników wyszukiwania
         * 
         
          
         *  
         * Pow_dzial_from Pow_dzial_to
            Droga_dojazdowa
            Kanalizacja
            woda
            elektr
            sila
            gaz
            media_opis
            media_woda
            media_elektr
            media_sila
            media_gaz
            media
            Material
            Kuchnia
            Developer
            Wtorny            
        */
    }



}