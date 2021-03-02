Imports System.IO
Imports System.Net
Imports Newtonsoft
Imports Newtonsoft.Json

Public Class BING

    Public Function gpsPorEndereco(nomeEndereco As String) As PontoGPS
        Dim url As String = "http://dev.virtualearth.net/REST/v1/Locations/" & nomeEndereco & "?maxResults=10&key=Ar8YYZNP0L3VIOgzyxMpQ7AoU9BIhP2dGB86FiaPtcBQL_j6i2ZdTcdjC5_OiT0V"

        Dim request As WebRequest = WebRequest.Create(url)
        Dim ws As WebResponse = request.GetResponse

        Dim dataStream As Stream = ws.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim str As String = reader.ReadToEnd()

        Dim obj As JSON_Result_LatLong
        obj = JsonConvert.DeserializeObject(Of JSON_Result_LatLong)(str)

        Dim latitude As String = obj.resourceSets(0).resources(0).point.coordinates(0)
        Dim longitude As String = obj.resourceSets(0).resources(0).point.coordinates(1)

        Dim pontoGEO As New PontoGPS


        ' MsgBox("latitude: " & latitude & " -- Longitude: " & longitude)
        pontoGEO.latitude = latitude
        pontoGEO.longitude = longitude

        Return pontoGEO

    End Function


    Public Function calcularKM(EnderecoInicial As String, EnderecoFinal As String) As String
        Dim url As String = "http://dev.virtualearth.net/REST/V1/Routes/Driving?wp.0=" & EnderecoInicial & "&wp.1=" & EnderecoFinal & "&routeAttributes=excludeItinerary&key=Ar8YYZNP0L3VIOgzyxMpQ7AoU9BIhP2dGB86FiaPtcBQL_j6i2ZdTcdjC5_OiT0V"
        Dim request As WebRequest = WebRequest.Create(url)
        Dim ws As WebResponse = request.GetResponse

        Dim dataStream As Stream = ws.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim str As String = reader.ReadToEnd()

        Dim obj As JSON_result
        obj = JsonConvert.DeserializeObject(Of JSON_result)(str)

        Dim km = obj.resourceSets(0).resources(0).travelDistance

        Return km


    End Function
    Public Class JSON_Result_LatLong

        Public resourceSets As List(Of PublicDataClassLatLong)

    End Class
    Public Class PublicDataClassLatLong
        Public estimatedTotal As String
        Public resources As List(Of PublicResourcesLatLong)
    End Class
    Public Class PublicResourcesLatLong
        Public name As String
        'Public bbox As JsonArrayAttribute
        Public point As PublicPointLatLong

    End Class
    Public Class PublicPointLatLong
        Public type As String
        Public coordinates As List(Of String)

    End Class
    Public Class Lista
        Public v1 As Integer
        Public v2 As Integer
        ' Public coordinates As Integer()

    End Class

    Public Class JSON_result
        Public resourceSets As List(Of PublicDataClass)

    End Class

    Public Class PublicDataClass
        Public estimatedTotal As String
        Public resources As List(Of PublicResources)
    End Class



    Public Class PublicResources
            Public travelDistance As String
        Public travelDuration As String
        '  Public point As List(Of PublicPoint)

    End Class

        Public Class PontoGPS

            Public latitude As String
            Public longitude As String

        End Class



    End Class
