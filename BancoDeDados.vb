Imports System.Data.SqlClient

Public Class BancoDeDados

    'Dim connectionString As String = "Server=DESKTOP-L8Q386T\MSG;Database=vistoria_db;User Id=sa;Password=l9l6l3L2@@"

    Dim connectionString As String = "Server=10.207.42.219;Database=MAPFRE;User Id=sa;Password=l9l6l3L2@@"


    Public Function pontoGEOBaseInterna(nomeEndereco As String) As BING.PontoGPS

        'Dim connectionString As String = "Server=DESKTOP-L8Q386T\MSG;Database=vistoria_db;User Id=sa;Password=l9l6l3L2@@"
        Dim sql As String = "select top 1 endereco_inicio, latitude, longitude from consulta_lat_long where endereco_inicio = '" & nomeEndereco & "'"
        Dim connection As New SqlConnection(connectionString)
        Dim dataadapter As New SqlDataAdapter(sql, connection)
        Dim ds As New DataSet()
        connection.Open()
        dataadapter.Fill(ds, "endereco_inicio")
        connection.Close()

        Dim PontoGEO As New BING.PontoGPS

        If ds.Tables(0).Rows.Count > 0 Then
            PontoGEO.latitude = ds.Tables(0).Rows(0)(1)
            PontoGEO.longitude = ds.Tables(0).Rows(0)(2)
        Else
            PontoGEO.latitude = ""
            PontoGEO.longitude = ""
        End If

        Return PontoGEO

    End Function

    Public Function kmBaseInterna(nomeEnderecoInicio As String, nomeEnderecoDestino As String) As String

        'Dim connectionString As String = "Server=DESKTOP-L8Q386T\MSG;Database=vistoria_db;User Id=sa;Password=l9l6l3L2@@"
        Dim sql As String = "select top 1 endereco_inicio , endereco_destino , km from consulta_km where endereco_inicio = '" & nomeEnderecoInicio & "' and endereco_destino = '" & nomeEnderecoDestino & "'"
        Dim connection As New SqlConnection(connectionString)
        Dim dataadapter As New SqlDataAdapter(sql, connection)
        Dim ds As New DataSet()
        connection.Open()
        dataadapter.Fill(ds, "endereco_inicio")
        connection.Close()

        Dim resultadoKM As String = ""

        If ds.Tables(0).Rows.Count > 0 Then
            resultadoKM = ds.Tables(0).Rows(0)(2)
        End If

        Return resultadoKM

    End Function


    Public Sub inserirEnderecoNaBase(nomeEndereco As String, latitude As String, longitude As String)

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Try
            con.ConnectionString = connectionString
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "INSERT INTO consulta_lat_long(endereco_inicio, latitude, longitude) VALUES('" & nomeEndereco & "','" & latitude & "','" & longitude & "' )"
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Error while inserting record on table..." & ex.Message, "Insert Records")
        Finally
            con.Close()
        End Try


    End Sub


    Public Sub inserirKmNaBase(nomeEnderecoInicio As String, nomeEnderecoDestino As String, km As String)

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Try
            con.ConnectionString = connectionString
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "INSERT INTO consulta_km(endereco_inicio, endereco_destino, km) VALUES('" & nomeEnderecoInicio & "','" & nomeEnderecoDestino & "','" & km & "' )"
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Error while inserting record on table..." & ex.Message, "Insert Records")
        Finally
            con.Close()
        End Try


    End Sub

    Public Sub inserirDemandaBase(wf_id As String, prestador_id As String, username As String)

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Try
            con.ConnectionString = connectionString
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "insert into tb_demanda_vistoria (wf_id, prestador_id, username , data  ) values ('" & wf_id & "','" & prestador_id & "' , '" & username & "', CURRENT_TIMESTAMP )"
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Error while inserting record on table..." & ex.Message, "Insert Records")
        Finally
            con.Close()
        End Try

    End Sub

    Public Function prestadoresProximos(PontoGEO As BING.PontoGPS) As DataSet

        ' Dim connectionString As String = "Server=DESKTOP-L8Q386T\MSG;Database=vistoria_db;User Id=sa;Password=l9l6l3L2@@"
        Dim sql As String = "SELECT a.id_prestador,a.nome,b.codigo_ibge,b.nome as nome_cidade_ibge,c.uf as uf_ibge,b.latitude,b.longitude,     (6371 * acos( cos( radians(" & PontoGEO.latitude & ") )  * cos( radians( latitude ) )  * cos( radians( longitude ) - radians( " & PontoGEO.longitude & ") )  + sin( radians( " & PontoGEO.latitude & " ) )  * sin( radians( latitude ) ) ) ) AS distancia, '0' as distancia_real FROM prestadores a left join municipios b on (a.codigo_ibge = b.codigo_ibge) left join estados c on (b.codigo_uf = c.codigo_uf)   ORDER BY distancia  "
        Dim connection As New SqlConnection(connectionString)
        Dim dataadapter As New SqlDataAdapter(sql, connection)
        Dim ds As New DataSet()
        connection.Open()
        dataadapter.Fill(ds, "id_prestador")
        connection.Close()
        'DataGridView1.DataSource = ds
        'DataGridView1.DataMember = "id_prestador"

        Return ds

    End Function

    Public Function prestadoresAnteriores(wf_id As String) As DataSet

        ' Dim connectionString As String = "Server=DESKTOP-L8Q386T\MSG;Database=vistoria_db;User Id=sa;Password=l9l6l3L2@@"
        Dim sql As String = "select prestador_id from tb_demanda_vistoria where wf_id = " & wf_id
        Dim connection As New SqlConnection(connectionString)
        Dim dataadapter As New SqlDataAdapter(sql, connection)
        Dim ds As New DataSet()
        connection.Open()
        dataadapter.Fill(ds, "id_prestador")
        connection.Close()
        'DataGridView1.DataSource = ds
        'DataGridView1.DataMember = "id_prestador"

        Return ds

    End Function

    Public Function inspecaoID(wfID As String) As String
        Dim con As New SqlConnection
        Dim reader As SqlDataReader
        Try
            con.ConnectionString = "Data Source=10.207.42.219;Initial Catalog=MAPFRE;Persist Security Info=True;User ID=sa;Password=l9l6l3L2@@"
            Dim cmd As New SqlCommand("select wf_id, inspecao_id from extrator_abs.vistoria_db.dbo.inspecao_tb where wf_id = " & wfID, con)
            con.Open()
            Console.WriteLine("Connection Opened")

            ' Execute Query    '
            reader = cmd.ExecuteReader()
            While reader.Read()
                Console.WriteLine(String.Format("{0}, {1}",
               reader(0), reader(1)))
                'NOTE: (^^) You are trying to read 2 columns here, but you only        '
                '   SELECT-ed one (username) originally...                             '
                ' , Also, you can call the columns by name(string), not just by number '
                Dim numInspecaoID = reader(1)
                Return numInspecaoID
            End While

        Catch ex As Exception
            MessageBox.Show("Error while connecting to SQL Server." & ex.Message)
        Finally
            con.Close() 'Whether there is error or not. Close the connection.    '
        End Try
        'Return reader { note: reader is not valid after it is closed }          '
        Return ""
    End Function


    Public Sub atualizarBasePrestador()
        Dim con As New SqlConnection
        '  Dim reader As SqlDataReader
        Try
            con.ConnectionString = "Data Source=10.207.42.219;Initial Catalog=MAPFRE;Persist Security Info=True;User ID=sa;Password=l9l6l3L2@@"
            Dim cmd As New SqlCommand("BULK INSERT prestadores FROM '\\10.207.42.219\base_msg\Base_Prestador\prestadores.csv' WITH (   CODEPAGE = '1252',   FIELDTERMINATOR = ';',   CHECK_CONSTRAINTS ) ", con)
            con.Open()
            Console.WriteLine("Connection Opened")
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Error while connecting to SQL Server." & ex.Message)
        Finally
            con.Close() 'Whether there is error or not. Close the connection.    '
        End Try
        'Return reader { note: reader is not valid after it is closed }          '

    End Sub


    Public Sub apagarBasePrestador()
        Dim con As New SqlConnection
        '  Dim reader As SqlDataReader
        Try
            con.ConnectionString = "Data Source=10.207.42.219;Initial Catalog=MAPFRE;Persist Security Info=True;User ID=sa;Password=l9l6l3L2@@"
            Dim cmd As New SqlCommand("delete from prestadores", con)
            con.Open()
            Console.WriteLine("Connection Opened")
            cmd.ExecuteNonQuery()
            MsgBox("Base Atualizada", vbInformation, "Atenção")
        Catch ex As Exception
            MessageBox.Show("Error while connecting to SQL Server." & ex.Message)
        Finally
            con.Close() 'Whether there is error or not. Close the connection.    '
        End Try
        'Return reader { note: reader is not valid after it is closed }          '

    End Sub



    '    CREATE TABLE consulta_lat_long (
    '    endereco_inicio varchar(255),
    '    latitude varchar(255),
    '    longitude varchar(255)

    ')



    'CREATE TABLE consulta_km (
    '    endereco_inicio varchar(255),
    '    endereco_destino varchar(255),
    '    km varchar(255)

    ')


End Class
