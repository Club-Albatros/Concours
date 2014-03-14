' Source: http://www.swisstopo.admin.ch/internet/swisstopo/en/home/topics/survey/sys/refsys/projections.html (see PDFs under "Documentation")

Namespace Conversions
 ''' <summary>
 ''' Summary description for ApproxSwissProj.
 ''' </summary>
 Public Class SwissProjection

  Public Shared Sub LV03toWGS84(east As Double, north As Double, height As Double, ByRef latitude As Double, ByRef longitude As Double, ByRef ellHeight As Double)
   latitude = CHtoWGSlat(east, north)
   longitude = CHtoWGSlng(east, north)
   ellHeight = CHtoWGSheight(east, north, height)
   Return
  End Sub

  Public Shared Sub WGS84toLV03(latitude As Double, longitude As Double, ellHeight As Double, ByRef east As Double, ByRef north As Double, ByRef height As Double)
   east = WGStoCHy(latitude, longitude)
   north = WGStoCHx(latitude, longitude)
   height = WGStoCHh(latitude, longitude, ellHeight)
   Return
  End Sub


  ' Convert WGS lat/long (° dec) to CH y
  Private Shared Function WGStoCHy(lat As Double, lng As Double) As Double
   ' Converts degrees dec to sex
   lat = DecToSexAngle(lat)
   lng = DecToSexAngle(lng)

   ' Converts degrees to seconds (sex)
   lat = SexAngleToSeconds(lat)
   lng = SexAngleToSeconds(lng)

   ' Axiliary values (% Bern)
   Dim lat_aux As Double = (lat - 169028.66) / 10000
   Dim lng_aux As Double = (lng - 26782.5) / 10000

   ' Process Y
   Dim y As Double = 600072.37 + 211455.93 * lng_aux - 10938.51 * lng_aux * lat_aux - 0.36 * lng_aux * Math.Pow(lat_aux, 2) - 44.54 * Math.Pow(lng_aux, 3)

   Return y
  End Function

  ' Convert WGS lat/long (° dec) to CH x
  Private Shared Function WGStoCHx(lat As Double, lng As Double) As Double
   ' Converts degrees dec to sex
   lat = DecToSexAngle(lat)
   lng = DecToSexAngle(lng)

   ' Converts degrees to seconds (sex)
   lat = SexAngleToSeconds(lat)
   lng = SexAngleToSeconds(lng)

   ' Axiliary values (% Bern)
   Dim lat_aux As Double = (lat - 169028.66) / 10000
   Dim lng_aux As Double = (lng - 26782.5) / 10000

   ' Process X
   Dim x As Double = 200147.07 + 308807.95 * lat_aux + 3745.25 * Math.Pow(lng_aux, 2) + 76.63 * Math.Pow(lat_aux, 2) - 194.56 * Math.Pow(lng_aux, 2) * lat_aux + 119.79 * Math.Pow(lat_aux, 3)

   Return x
  End Function

  ' Convert WGS lat/long (° dec) and height to CH h
  Private Shared Function WGStoCHh(lat As Double, lng As Double, h As Double) As Double
   ' Converts degrees dec to sex
   lat = DecToSexAngle(lat)
   lng = DecToSexAngle(lng)

   ' Converts degrees to seconds (sex)
   lat = SexAngleToSeconds(lat)
   lng = SexAngleToSeconds(lng)

   ' Axiliary values (% Bern)
   Dim lat_aux As Double = (lat - 169028.66) / 10000
   Dim lng_aux As Double = (lng - 26782.5) / 10000

   ' Process h
   h = h - 49.55 + 2.73 * lng_aux + 6.94 * lat_aux

   Return h
  End Function



  ' Convert CH y/x to WGS lat
  Private Shared Function CHtoWGSlat(y As Double, x As Double) As Double
   ' Converts militar to civil and  to unit = 1000km
   ' Axiliary values (% Bern)
   Dim y_aux As Double = (y - 600000) / 1000000
   Dim x_aux As Double = (x - 200000) / 1000000

   ' Process lat
   Dim lat As Double = 16.9023892 + 3.238272 * x_aux - 0.270978 * Math.Pow(y_aux, 2) - 0.002528 * Math.Pow(x_aux, 2) - 0.0447 * Math.Pow(y_aux, 2) * x_aux - 0.014 * Math.Pow(x_aux, 3)

   ' Unit 10000" to 1 " and converts seconds to degrees (dec)
   lat = lat * 100 / 36

   Return lat
  End Function

  ' Convert CH y/x to WGS long
  Private Shared Function CHtoWGSlng(y As Double, x As Double) As Double
   ' Converts militar to civil and  to unit = 1000km
   ' Axiliary values (% Bern)
   Dim y_aux As Double = (y - 600000) / 1000000
   Dim x_aux As Double = (x - 200000) / 1000000

   ' Process long
   Dim lng As Double = 2.6779094 + 4.728982 * y_aux + 0.791484 * y_aux * x_aux + 0.1306 * y_aux * Math.Pow(x_aux, 2) - 0.0436 * Math.Pow(y_aux, 3)

   ' Unit 10000" to 1 " and converts seconds to degrees (dec)
   lng = lng * 100 / 36

   Return lng
  End Function

  ' Convert CH y/x/h to WGS height
  Private Shared Function CHtoWGSheight(y As Double, x As Double, h As Double) As Double
   ' Converts militar to civil and  to unit = 1000km
   ' Axiliary values (% Bern)
   Dim y_aux As Double = (y - 600000) / 1000000
   Dim x_aux As Double = (x - 200000) / 1000000

   ' Process height
   h = h + 49.55 - 12.6 * y_aux - 22.64 * x_aux

   Return h
  End Function



  ' Convert sexagesimal angle (degrees, minutes and seconds "dd.mmss") to decimal angle (degrees)
  Public Shared Function SexToDecAngle(dms As Double) As Double
   ' Extract DMS
   ' Input: dd.mmss(,)ss
   Dim deg As Double = 0, min As Double = 0, sec As Double = 0
   deg = Math.Floor(dms)
   min = Math.Floor((dms - deg) * 100)
   sec = (((dms - deg) * 100) - min) * 100

   ' Result in degrees dec (dd.dddd)
   Return deg + min / 60 + sec / 3600
  End Function

  ' Convert decimal angle (degrees) to sexagesimal angle (degrees, minutes and seconds dd.mmss,ss)
  Public Shared Function DecToSexAngle(dec As Double) As Double
   Dim deg As Integer = CInt(Math.Truncate(Math.Floor(dec)))
   Dim min As Integer = CInt(Math.Truncate(Math.Floor((dec - deg) * 60)))
   Dim sec As Double = (((dec - deg) * 60) - min) * 60

   ' Output: dd.mmss(,)ss
   Return deg + CDbl(min) / 100 + CDbl(sec) / 10000
  End Function

  ' Convert sexagesimal angle (degrees, minutes and seconds dd.mmss,ss) to seconds
  Public Shared Function SexAngleToSeconds(dms As Double) As Double
   Dim deg As Double = 0, min As Double = 0, sec As Double = 0
   deg = Math.Floor(dms)
   min = Math.Floor((dms - deg) * 100)
   sec = (((dms - deg) * 100) - min) * 100

   ' Result in degrees sex (dd.mmss)
   Return sec + CDbl(min) * 60 + CDbl(deg) * 3600
  End Function

 End Class
End Namespace
