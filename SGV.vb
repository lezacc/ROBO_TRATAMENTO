

Public Class SGV



#Region "VARIAVEIS"
    Private VALOR_TOKEN As String = ""
    Private LINK_PAGINA_INICIAL As String = "http://www.aliancadobrasil.com.br/SGVS/SGVW0008/principal.aspx?"
    Private ID_SENHA As String = "uctLogon_txtPassword"
    Private ID_BOTAO_OK As String = "uctLogon_btnLogon"
    Private ID_TABELA As String = "ctl00_body_tabelaNome"
    Private ID_BOTAO_PESQUISAR As String = "ctl00_body_btnBuscar"
    Private ID_BOTAO_LIMPAR As String = "ctl00_body_btnMudar"
    Private ID_BOTAO_BUSCAR As String = "ctl00_body_ty"
    Private ID_BOTAO_ALTERAR As String = "ctl00_body_btnAlterar"
    Private ID_BOTAO_INSERIR As String = "ctl00_body_btnShowIncluir"
    Private ID_BOTAO_DELETAR As String = "ctl00_body_btnDeletar"
    Private ID_BOTAO_CONFIRMAR As String = "ctl00_body_btnConfirmarOperacao"
    Private ID_TXT_QUANTIDADE_LINHAS_INSERIR As String = "ctl00_body_quantidadeInsert"
    Private ID_BOTAO_INCLUIR_QUANTIDADE As String = "ctl00_body_btnIncluir"
    Private ID_MENSAGEM_SUCESSO As String = "ctl00_lblMsgSucesso"
    Private ID_MENSAGEM_ERRO As String = "ctl00_lblMsgErro"
    Private WWW As New WebBrowser
    Private Property pageready As Boolean = False

#End Region

#Region "ATRIBUTOS"
    Public WEB As WebBrowser = WWW
    Public TOKEN As String = VALOR_TOKEN
    Public ATIVIDADE As New Atividade
#End Region

#Region "SUB_AGUARDAR_PAGINA"
    Private Sub WaitForPageLoad()
        AddHandler WEB.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        While Not pageready
            System.Threading.Thread.Sleep(0)
            Application.DoEvents()
        End While
        preventScript()
        pageready = False
    End Sub

    Private Sub PageWaiter(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
        If WEB.ReadyState = WebBrowserReadyState.Complete Then
            'InjectAlertBlocker()
            pageready = True
            RemoveHandler WEB.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        End If
    End Sub

#End Region

    Public Sub logarSGV()

        WEB.Navigate(LINK_PAGINA_INICIAL & TOKEN)
        WaitForPageLoad()

    End Sub


    Public Sub selecionarAtividade(indice As String)

        WEB.Document.GetElementById("ddlAtividade").SetAttribute("value", indice)
        WEB.Document.GetElementById("btnContinuar").InvokeMember("click")
        WaitForPageLoad()
        WEB.Document.GetElementById("btnContinuar").InvokeMember("click")
        WaitForPageLoad()

    End Sub

    Public Function tabelaDTGInstanciasParaDataTable() As DataTable
        Dim Document As New HtmlAgilityPack.HtmlDocument()
        Dim table As HtmlAgilityPack.HtmlNode
        Dim paginas As HTMLElementCollection = WEB.Document.GetElementById("lblPaginacao").GetElementsByTagName("a")

        Dim dt As New DataTable()
        Dim pagina1 As Boolean = True


        For p As Integer = 0 To paginas.Count

            Document.LoadHtml(WEB.DocumentText)
            table = Document.DocumentNode.SelectSingleNode("//*[@id='dtgInstancias']") '//*[@id="dtgInstancias"]/tbody

            Dim rows = table.SelectNodes("tr")

            For row As Integer = 0 To rows.Count - 1
                'if row = then these are headers
                If row = 0 Then
                    If pagina1 Then
                        pagina1 = False
                        Dim cols = rows(row).SelectNodes("td")

                        For c As Integer = 0 To cols.Count - 1
                            dt.Columns.Add(New DataColumn(cols(c).InnerText.ToString()))
                        Next
                    End If

                Else
                    Dim cols = rows(row).SelectNodes("td")
                    Dim dr As DataRow = dt.NewRow()
                    For c As Integer = 0 To cols.Count - 1
                        dr(c) = cols(c).InnerText.ToString()
                    Next

                    dt.Rows.Add(dr)


                End If
            Next
            proximaPagina()
        Next

        'dt.Columns.Remove(TabelaDTGINstancia.nbsp)

        Return dt

    End Function


    Private Sub proximaPagina()
        Dim paginas As HTMLElementCollection = WEB.Document.GetElementById("lblPaginacao").GetElementsByTagName("a")

        For Each pagina As HtmlElement In paginas
            If pagina.InnerHtml = "Próxima" Then
                pagina.InvokeMember("click")
                WaitForPageLoad()
                Exit Sub
            End If

        Next

    End Sub

    Public Sub validacaoDaPrevalorizacao(usuarioID As String, WF_ID As String, INSPECAO_ID As String, TOKEN As String)
        WEB.ScriptErrorsSuppressed = True

        Dim link As String = "http://www.aliancadobrasil.com.br/SGVS/SGVW0008/ListaTarefas.aspx?usuario_id=" & usuarioID & "," & usuarioID & "&tp_wf_id=168,168&tp_versao_id=1,1&coluna_exibicao=1|1|1|1|1|1|1|1|1|1|1|1|1&tp_ativ_id=4&wf_id=" & WF_ID & "&inspecaoid=" & INSPECAO_ID & "&" & TOKEN

        WEB.Navigate(link)
        WaitForPageLoad()
        WEB.Document.GetElementById("6").InvokeMember("click")
        WaitForPageLoad()
        WEB.Document.GetElementById("BtnFinalizar").InvokeMember("click")

    End Sub

    Public Sub cancelamentoDaPrevalorizacao(usuarioID As String, WF_ID As String, INSPECAO_ID As String, TOKEN As String)
        WEB.ScriptErrorsSuppressed = True
        Dim link As String = "http://www.aliancadobrasil.com.br/SGVS/SGVW0008/ListaTarefas.aspx?usuario_id=" & usuarioID & "," & usuarioID & "&tp_wf_id=168,168&tp_versao_id=1,1&coluna_exibicao=1|1|1|1|1|1|1|1|1|1|1|1|1&tp_ativ_id=4&wf_id=" & WF_ID & "&inspecaoid=" & INSPECAO_ID & "&" & TOKEN

        WEB.Navigate(link)
        WaitForPageLoad()
        WEB.Document.GetElementById("5").InvokeMember("click")
        WaitForPageLoad()
        WEB.Document.GetElementById("txtobs").SetAttribute("value", ".")
        WEB.Document.GetElementById("ddlMotivo").SetAttribute("value", "1")
        WEB.Document.GetElementById("BtnFinalizar").InvokeMember("click")

    End Sub


    Public Sub liberacaoPreValidacao(usuarioID As String, WF_ID As String, INSPECAO_ID As String, TOKEN As String)
        WEB.ScriptErrorsSuppressed = True
        Dim link As String = "http://www.aliancadobrasil.com.br/SGVS/SGVW0008/ListaTarefas.aspx?usuario_id=" & usuarioID & "," & usuarioID & "&tp_wf_id=168,168&tp_versao_id=1,1&coluna_exibicao=1|1|1|1|1|1|1|1|1|1|1|1|1&tp_ativ_id=13&wf_id=" & WF_ID & "&inspecaoid=" & INSPECAO_ID & "&" & TOKEN

        WEB.Navigate(link)
        WaitForPageLoad()
        WEB.Document.GetElementById("21").InvokeMember("click")
        WaitForPageLoad()

        Dim quilometragem As Double = converterString(WEB.Document.GetElementById("lblKmVariacao").InnerHtml)

        If quilometragem <= 10 Then
            WEB.Document.GetElementById("btnFinalizar").InvokeMember("click")
        Else
            WEB.Document.GetElementById("btnsair").InvokeMember("click")
        End If

    End Sub
    Public Sub selecionarPrestadorF(empresa As String, quilometragem As String, observacao As String, wfID As String, inspecaoID As String, TOKEN_F As String)
        WEB.ScriptErrorsSuppressed = True

        Dim link As String = "http://www.aliancadobrasil.com.br/SGVS/SGVW0008/ListaTarefas.aspx?usuario_id=32189,32189&tp_wf_id=168,168&tp_versao_id=1,1&coluna_exibicao=1|1|1|1|1|1|1|1|1|1|1|1|1&tp_ativ_id=2&wf_id=" & wfID & "&inspecaoid=" & inspecaoID & "&" & TOKEN_F

        'MsgBox(link)

        WEB.Navigate(link)
        WaitForPageLoad()


        WEB.Document.GetElementById("12").InvokeMember("click")
        WaitForPageLoad()


        WEB.Document.GetElementById("txtobs").SetAttribute("value", observacao)

            WEB.Document.GetElementById("btnTotalizar").InvokeMember("click")
            WaitForPageLoad()

        WEB.Document.GetElementById("btnFinalizar").InvokeMember("click")


    End Sub
    Public Sub preventScript()

        Dim doc As HtmlDocument = WEB.Document
        Dim head As HtmlElement = doc.GetElementsByTagName("head")(0)
        Dim s As HtmlElement = doc.CreateElement("script")
        s.SetAttribute("text", "function cancelOut() { window.onbeforeunload = null; }")
        head.AppendChild(s)
        WEB.Document.InvokeScript("cancelOut")


    End Sub

    Public Function pegarInspecaoID(sSource As String) As String
        pegarInspecaoID = ""

        Dim sDelimStart As String = "inspecaoid=" 'First delimiting word
        Dim sDelimEnd As String = "&amp;pqsSeguranca" 'Second delimiting word
        Dim nIndexStart As Integer = sSource.IndexOf(sDelimStart) 'Find the first occurrence of f1
        Dim nIndexEnd As Integer = sSource.IndexOf(sDelimEnd) 'Find the first occurrence of f2

        If nIndexStart > -1 AndAlso nIndexEnd > -1 Then '-1 means the word was not found.
            Dim res As String = Strings.Mid(sSource, nIndexStart + sDelimStart.Length + 1, nIndexEnd - nIndexStart - sDelimStart.Length) 'Crop the text between
            pegarInspecaoID = res
            '  Else
            ' MessageBox.Show("One or both of the delimiting words were not found!")
        End If


    End Function

    Public Function inspecaoIdViaSGV(wf_id As String) As String
        Try
            WEB.Document.GetElementById("txtWfId").SetAttribute("value", wf_id)
            WEB.Document.GetElementById("btnContinuar").InvokeMember("click")
            WaitForPageLoad()
            WEB.Document.GetElementById("btnContinuar").InvokeMember("click")
            WaitForPageLoad()

            WEB.Document.GetElementById(wf_id).InvokeMember("click")
            WaitForPageLoad()

            Dim linhasTabelaAtividade As HtmlElementCollection = WEB.Document.GetElementById("DtGInspecaoSituacaoHist").GetElementsByTagName("tbody").Item(0).GetElementsByTagName("tr")
            Dim executadoEm As HtmlElement
            Dim inspecaoID As String = ""
            For Each linhaTabelaAtividade As HtmlElement In linhasTabelaAtividade

                executadoEm = linhaTabelaAtividade.GetElementsByTagName("td").Item(0)
                If Len(executadoEm.InnerHtml) > 15 Then

                    inspecaoID = pegarInspecaoID(executadoEm.InnerHtml)

                End If

            Next
            inspecaoIdViaSGV = inspecaoID

        Catch ex As Exception
            inspecaoIdViaSGV = ""
        End Try

    End Function



    Public Function converterString(str As String) As Double
        converterString = CDbl(Microsoft.VisualBasic.Replace(str, "%", "", 1))

    End Function
    Public Sub selecionarPrestador(empresa As String, quilometragem As String, observacao As String, wfID As String, inspecaoID As String, token_f As String)

        WEB.ScriptErrorsSuppressed = True
        WEB.Navigate("http://www.aliancadobrasil.com.br/SGV/SGVW0008/ListaTarefas.aspx?usuario_id=32189,32189&tp_wf_id=168,168&tp_versao_id=1,1&coluna_exibicao=1|1|1|1|1|1|1|1|1|1|1|1|1&tp_ativ_id=2&wf_id=" & wfID & "&inspecaoid=" & inspecaoID & "&" & token_f)
        WaitForPageLoad()

        WEB.Document.GetElementById("11").InvokeMember("click")
        WaitForPageLoad()


        WEB.Document.GetElementById("txtobs").SetAttribute("value", observacao)


        WaitForPageLoad()

            WEB.Document.GetElementById("btnFinalizar").InvokeMember("click")
        ' mainForm.tmrPopCheck.Start()
        ' WEB.Navigate("www.google.com")


    End Sub

    Private Function nomeMunicipioPrestadorSelecionado(web As WebBrowser) As String
        Dim comboMunicipioPrestado As HTMLElementCollection = web.Document.GetElementById("ddlMunicipioBase").GetElementsByTagName("option")
        Dim municipioPrestador As String = ""

        For Each opt As HtmlElement In comboMunicipioPrestado
            If opt.GetAttribute("selected") = True Then
                municipioPrestador = opt.InnerHtml
                Exit For
            End If

        Next
        nomeMunicipioPrestadorSelecionado = municipioPrestador
    End Function


    Public Function nomeMunicipioDestino(web As WebBrowser) As String
        nomeMunicipioDestino = web.Document.GetElementById("lblMunicipioDestino").InnerHtml

    End Function

End Class

Public Class Atividade
    Public SelecaoEmpresa As String = "2"
    Public ValidacaoPreValorizacao = "4"
    Public ValidacaoDaValorizacao = "13"
End Class

Public Class TabelaDTGInstancias
    Public nbsp As String = "&nbsp;"
    Public Workflow_ID As String = "Workflow ID"
    Public Data_de_inclusão As String = "Data de inclusão"
    Public Data_da_ultima_execução As String = "Data da ultima execução"
    Public Tipo_de_inspeção As String = "Tipo de inspeção"
    Public Situacao As String = "Situação"
    Public sub_ramo As String = "Sub ramo"
    Public Proponente As String = "Proponente"
    Public CNPJ As String = "CNPJ"
    Public Endereco As String = "Endereço"
    Public Municipio As String = "Município"
    Public UF As String = "UF"
    Public Data_de_agendamento As String = "Data de agendamento"
    Public Prestador As String = "Prestador"

End Class

