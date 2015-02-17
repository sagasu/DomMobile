namespace Trader.Model.Solr
{
    using System;

    public interface ISolrAdvert
    {
        /// <summary>
        ///   Gets or sets Id -  odpowiednik pola Id z allads - id og³oszenia.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        ///   Gets or sets UserId -  odpowiednik pola UserId z allads - Id usera który jest w³aœcicielem og³oszenia.
        /// </summary>
        
        int UserId { get; set; }

        /// <summary>
        ///   Gets or sets UserName -  odpowiednik pola Name z Users.
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        ///   Gets or sets UserType -  odpowiednik pola Type z Users.
        /// </summary>

        string UserType { get; set; }

        /// <summary>
        ///   Gets or sets UserStatus -  odpowiednik pola Status z Users.
        /// </summary>
        string UserStatus { get; set; }

        /// <summary>
        ///   Gets or sets UserLogo -  odpowiednik pola Logo z Users.
        /// </summary>
        string UserLogo { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether HasUserLogo.
        /// </summary>
        bool HasUserLogo { get; set; }

        /// <summary>
        ///   Gets or sets Active -  odpowiednik pola Active z allads.
        /// </summary>
        int Active { get; set; }

        /// <summary>
        ///   Gets or sets Premium -  odpowiednik pola Premium z allads.
        /// </summary>
        int Premium { get; set; }

        /// <summary>
        ///   Gets or sets CategoryId -  odpowiednik pola CategoryId z allads.
        /// </summary>
        int CategoryId { get; set; }

        /// <summary>
        ///   Gets or sets CategoryPath -  odpowiednik pola Path z allads.
        /// </summary>
        string CategoryPath { get; set; }

        /// <summary>
        ///   Gets or sets InsertionDate -  odpowiednik pola InsertionDate z allads.
        /// </summary>
        DateTime InsertionDate { get; set; }

        /// <summary>
        ///   Gets or sets SortDate -  odpowiednik pola SortDate z allads.
        /// </summary>
        DateTime SortDate { get; set; }

        /// <summary>
        ///   Gets or sets Subject -  odpowiednik pola Temat z allads.
        /// </summary>
        string Subject { get; set; }

        /// <summary>
        ///   Gets or sets Name -  odpowiednik pola Name z allads.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///   Gets or sets Picture.
        /// </summary>
        string Picture { get; set; }

        /// <summary>
        ///   Gets or sets PictureCount.
        /// </summary>
        int PictureCount { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether is this has Picture
        /// </summary>
        bool HasPicture { get; set; }

        /// <summary>
        ///   Gets or sets Video.
        /// </summary>
        string Video { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether is this has Video.
        /// </summary>
        bool HasVideo { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether is it ExclusiveOffer.
        /// </summary>
        bool ExclusiveOffer { get; set; }

        /// <summary>
        ///   Gets or sets LocalPrice -  odpowiednik pola cena_LocalPrice z allads - cena wyra¿ona w z³otówkach.
        /// </summary>
        decimal? LocalPrice { get; set; }

        /// <summary>
        ///   Gets or sets SortFactor -  odpowiednik pola SumaWag z allads - istotny element zwiazany z sortowaniem jest tum wiêkszy im lepiej jest opisane og³oszenie.
        /// </summary>
        int SortFactor { get; set; }

        /// <summary>
        ///   Gets or sets TransactionType -  odpowiednik pola TRN z allads - 1: kupiê 2: sprzedam 3: wynajmê.
        /// </summary>
        int TransactionType { get; set; }

        /// <summary>
        ///   Gets or sets Region -  odpowiednik pola Region z allads ale w postaci stringowj - patrz dictRegions.
        /// </summary>
        string Region { get; set; }

        /// <summary>
        ///   Gets or sets District -  odpowiednik pola Powiat z allads.
        /// </summary>
        string District { get; set; }

        /// <summary>
        ///   Gets or sets City -  odpowiednik pola Miasto z allads.
        /// </summary>
        string City { get; set; }

        /// <summary>
        ///   Gets or sets Quarter -  odpowiednik pola Dzielnica z allads.
        /// </summary>
        string Quarter { get; set; }

        /// <summary>
        ///   Gets or sets Street -  odpowiednik pola Ulica z allads.
        /// </summary>
        string Street { get; set; }

        /// <summary>
        ///   Gets or sets GeoCodesLongtitude - zmienna geolokalizacyjna dla google maps przechowuj¹ca d³ugoœæ geograficzn¹.
        /// </summary>
        decimal? GeoCodesLongtitude { get; set; }

        /// <summary>
        ///   Gets or sets GeoCodesLatitude - zmienna geolokalizacyjna dla google maps przechowuj¹ca szerokoœæ geograficzn¹.
        /// </summary>
        decimal? GeoCodesLatitude { get; set; }

        /// <summary>
        ///   Gets or sets Status - dostêpne = 0, zarezerwowane = 1, sprzedane = 2.
        /// </summary>
        byte Status { get; set; }

        /// <summary>
        ///   Gets or sets PropertyType - odpowiednik pola Typ z allads.
        /// </summary>
        string PropertyType { get; set; }

        /// <summary>
        ///   Gets or sets PropertyType - odpowiednik pola ZrodloDanych z allads.
        /// </summary>
        string SourceDataKind { get; set; }

        /// <summary>
        ///   Gets or sets PropertyType - odpowiednik pola ZrodloDanychLogo z allads.
        /// </summary>
        string SourceDataLogo { get; set; }

        /// <summary>
        ///   Gets or sets PropertyType - odpowiednik pola Kanalizacja z allads.
        /// </summary>
        string Sewerage { get; set; }

        /// <summary>
        ///   Gets or sets PropertyType - odpowiednik pola Media z allads.
        /// </summary>
        string Media { get; set; }

        /// <summary>
        ///   Gets or sets Kind - odpowiednik pola Rodzaj z allads.
        /// </summary>
        string Kind { get; set; }

        /// <summary>
        ///   Gets or sets Description - odpowiednik pola Opis.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        ///   Gets or sets Description - odpowiednik pola Przeznaczenie.
        /// </summary>
        string PropertyUsage { get; set; }

        /// <summary>
        ///   Gets or sets CommissionDate - odpowiednik pola TerminRealizacji.
        /// </summary>
        DateTime? CommissionDate { get; set; }

        /// <summary>
        ///   Gets or sets ContactData - odpowiednik pola Kontakt z allads i doklejone dane z tabelki users.
        /// </summary>
        string ContactData { get; set; }

        /// <summary>
        ///   Gets or sets PropertyCateory - odpowiednik pola Kategoria z allads.
        /// </summary>
        string PropertyCateory { get; set; }

        /// <summary>
        ///   Gets or sets SqMetAreal - odpowiednik pola Powierzchnia z allads.
        /// </summary>
        int? SqMetAreal { get; set; }

        /// <summary>
        ///   Gets or sets InvestmentId - odpowiednik pola inwestycjaid z allads - szukane pole Inwestycja.
        /// </summary>
        string InvestmentId { get; set; }

        /// <summary>
        ///   Gets or sets InvestmentPicture - odpowiednik pola inwestycjapicture z allads.
        /// </summary>
        string InvestmentPicture { get; set; }

        /// <summary>
        ///   Gets or sets Year - odpowiednik Rok.
        /// </summary>
        int? Year { get; set; }

        /// <summary>
        ///   Gets or sets LevelsCount - odpowiednik liczba_kondygnacji.
        /// </summary>
        int? LevelsCount { get; set; }

        /// <summary>
        ///   Gets or sets FloorsCount - odpowiednik Liczba_pieter.
        /// </summary>
        int? FloorsCount { get; set; }

        /// <summary>
        ///   Gets or sets FloorNum - odpowiednik Pietro.
        /// </summary>
        int? FloorNum { get; set; }

        /// <summary>
        ///   Gets or sets RoomsCount - odpowiednik Liczba_pokoi.
        /// </summary>
        int? RoomsCount { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether IsPrivate - dpowiednik priv.
        /// </summary>
        bool IsPrivate { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether IsDeveloper - dpowiednik Developer.
        /// </summary>
        bool IsDeveloper { get; set; }

        /// <summary>
        /// Gets or sets OfferNumber - odpowiednik nr_oferty.
        /// </summary>
        string OfferNumber { get; set; }

        /// <summary>
        ///   Gets or sets SqMetLivingAreal - odpowiednik pola Pow_miesz z allads.
        /// </summary>
        int? SqMetLivingAreal { get; set; }

        /// <summary>
        ///   Gets or sets SqMetParcelAreal - odpowiednik pola dzialka_powierzchnia, pow_dzial z allads.
        /// </summary>
        decimal? SqMetParcelAreal { get; set; }

        /// <summary>
        ///   Gets or sets ChambersCount - odpowiednik pola Liczba_pomieszczen z allads.
        /// </summary>
        int? ChambersCount { get; set; }

        /// <summary>
        ///   Gets or sets Random - odpowiednik pola Random z allads.
        /// </summary>
        int? Random { get; set; }

        /// <summary>
        ///   Gets or sets SqMetPrice - odpowiednik pola Cena_metra z allads.
        /// </summary>
        decimal? SqMetPrice { get; set; }

        /// <summary>
        ///   Gets or sets ConcatenatedAdvert - wylicza zlepione pola.
        /// </summary>
        string ConcatenatedAdvert { get; set; }

        /// <summary>
        /// Gets or sets RecordVer.
        /// </summary>
        string RecordVer { get; set; }

        /// <summary>
        /// Gets or sets Rynek.
        /// </summary>
        string Rynek { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsSelled.
        /// </summary>
        bool IsSelled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsSelled.
        /// </summary>
        string InvestmentGroupField { get; set; }

        string SerializedAdvertData { get; set; }

        DomiportaAdvertDetailsData AdvertData { get; }
    }
}