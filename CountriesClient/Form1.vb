Imports System.Net.Http
Imports Newtonsoft.Json

Public Class Form1
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim http As New HttpClient

        Dim data As String = Await http.GetStringAsync("https://restcountries.eu/rest/v2/all")

        Dim landen = JsonConvert.DeserializeObject(Of List(Of Country))(data)

        ComboBox1.DataSource = landen
        ComboBox1.DisplayMember = "name"

        Dim query = From l In landen
                    Where l.Region = "Europe"
                    Select l
                    Order By l.Population Descending

        dgv.DataSource = query.ToList
    End Sub

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim http As New HttpClient

        Dim data As String = Await http.GetStringAsync("https://restcountries.eu/rest/v2/currency/eur")

        Dim landen = JsonConvert.DeserializeObject(Of List(Of Country))(data)

        dgv.DataSource = landen
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GetCities()
    End Sub

    Async Sub GetCities()
        'Await kan alleen in Async functies!
        Dim data As String = Await http.GetStringAsync("")

        Dim steden = JsonConvert.DeserializeObject(Of List(Of City))(data)

        dgv.DataSource = steden
    End Sub

    Private Async Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim c As City = dgv.SelectedRows(0).DataBoundItem

        Await http.DeleteAsync("" & c.CityID)

        GetCities()
    End Sub


    Dim http As New HttpClient With {.BaseAddress = New Uri("https://xanderwemmers.nl/api/cities/")}

    Private Async Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim c As New City
        c.CityName = txtCityName.Text
        c.Country = ComboBox1.Text
        c.Population = txtPopulation.Text
        c.Year = txtYear.Text

        'Hiervoor is de Nuget Package Microsoft.AspNet.WebApi.Client nodig
        Await http.PostAsJsonAsync("", c)

        GetCities()
    End Sub

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim http As New HttpClient

        Dim data As String = Await http.GetStringAsync("https://restcountries.eu/rest/v2/all")

        Dim landen = JsonConvert.DeserializeObject(Of List(Of Country))(data)

        ComboBox1.DataSource = landen
        ComboBox1.DisplayMember = "name"
    End Sub
End Class
