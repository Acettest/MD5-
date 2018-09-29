using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;

namespace MD5Encrypt
{
    /// <summary>
    /// ��¼��־
    /// </summary>
    /// <param name="strlog">�쳣�ַ���</param>
    public delegate void delegateMD5SengLog(string strlog);

    /// <summary>
    /// MD5�ӿ�
    /// </summary>
    public interface IMD5Encrypt
    {
        
        /// <summary>
        /// �¼�:��¼������־
        /// </summary>
        event delegateMD5SengLog sendLog;

        /// <summary>
        /// ʹ��ȱʡ��Կ�����ַ���
        /// </summary>
        /// <param name="sInputString">��Ҫ���ܵ��ַ���</param>
        /// <returns>���ܺ��ַ���</returns>
        string EncryptString(string sInputString);

        /// <summary>
        /// ʹ��ȱʡ��Կ�����ַ���
        /// </summary>
        /// <param name="sInputString">��Ҫ�����ַ���</param>
        /// <returns>���ܺ��ַ���</returns>
        string DecryptString(string sInputString);

        /// <summary>
        /// ʹ��ȱʡ��Կ����XML�ļ�
        /// </summary>
        /// <param name="xmlpath">��Ҫ���ܵ�XML�ļ�����·��(�����ļ���)</param>
        /// <param name="count">��Ҫ���ܵ�λ��:1��ʾ8λ����,2��ʾ16λ����,3��ʾ24λ����...</param>
        /// <returns>���ܺ�XML�ļ��ı��ַ���</returns>
        string EncryptXML(string xmlpath, int count);

        /// <summary>
        /// ʹ��ȱʡ��Կ����XML�ļ�
        /// </summary>
        /// <param name="xmlpath">��Ҫ���ܵ�XML�ļ�����·��(�����ļ���)</param>
        /// <param name="count">��Ҫ���ܵ�λ��:1��ʾ����8λ����,2��ʾ����16λ����,3��ʾ����24λ����...</param>
        /// <returns>���ܺ�XML�ļ��ı��ַ���</returns>
        string DecryptXML(string xmlpath, int count);


        /// <summary>
        /// ʹ��ȱʡ��Կ������XML�ļ�,������DataSet
        /// </summary>
        /// <param name="xmlpath">��Ҫ���ܵ�XML�ļ�����·��(�����ļ���)</param>
        /// <param name="count">��Ҫ����ܵ�λ��:1��ʾ8λ����,2��ʾ16λ����,3��ʾ24λ����...</param>
        /// <returns>DataSet</returns>
        DataSet EncryptXML2DS(string xmlpath, int count);

        /// <summary>
        /// ʹ��ȱʡ��Կ����XML�ļ�,������DataSet
        /// </summary>
        /// <param name="xmlpath">��Ҫ���ܵ�XML�ļ�����·��(�����ļ���)</param>
        /// <param name="count">��Ҫ���ܵ�λ��:1��ʾ����8λ����,2��ʾ����16λ����,3��ʾ����24λ����...</param>
        /// <returns>DataSet</returns>
        DataSet DecryptXML2DS(string xmlpath, int count);

        /// <summary>
        /// ʹ��ȱʡ��Կ����XML�ļ�,������XmlDocument
        /// </summary>
        /// <param name="xmlpath">��Ҫ���ܵ�XML�ļ�����·��(�����ļ���)</param>
        /// <param name="count">��Ҫ���ܵ�λ��:1��ʾ8λ����,2��ʾ16λ����,3��ʾ24λ����...</param>
        /// <returns>XmlDocument</returns>
        XmlDocument EncryptXML2XmlDoc(string xmlpath, int count);

        /// <summary>
        /// ʹ��ȱʡ��Կ����XML�ļ�,������XmlDocument
        /// </summary>
        /// <param name="xmlpath">��Ҫ���ܵ�XML�ļ�����·��(�����ļ���)</param>
        /// <param name="count">��Ҫ���ܵ�λ��:1��ʾ����8λ����,2��ʾ����16λ����,3��ʾ����24λ����...</param>
        /// <returns>XmlDocument</returns>
        XmlDocument DecryptXML2XmlDoc(string xmlpath, int count);

        /// <summary>
        ///  ����DataSet��������DataSet
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="count">����λ��</param>
        /// <returns>DataSet</returns>
        DataSet EncryptDS2DS(DataSet ds, int count);

        /// <summary>
        /// ����DataSet��������DataSet
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="count">����λ��</param>
        /// <returns>DataSet</returns>
        DataSet DecrypDS2DS(DataSet ds, int count);

        /// <summary>
        ///  ����DataSet��������XmlDocument
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="count">����λ��</param>
        /// <returns>XmlDocument</returns>
        XmlDocument EncryptDS2XmlDoc(DataSet ds, int count);

        /// <summary>
        /// ����DataSet��������XmlDocument
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="count">����λ��</param>
        /// <returns>XmlDocument</returns>
        XmlDocument DecrypDS2XmlDoc(DataSet ds, int count);

        /// <summary>
        ///  ����XmlDocument��������DataSet
        /// </summary>
        /// <param name="doc">XmlDocument</param>
        /// <param name="count">����λ��</param>
        /// <returns>DataSet</returns>
        DataSet EncryptXmlDoc2DS(XmlDocument doc, int count);

        /// <summary>
        /// ����XmlDocument��������DataSet
        /// </summary>
        /// <param name="doc">XmlDocument</param>
        /// <param name="count">����λ��</param>
        /// <returns>DataSet</returns>
        DataSet DecrypXmlDoc2DS(XmlDocument doc, int count);

        /// <summary>
        ///  ����XmlDocument��������XmlDocument
        /// </summary>
        /// <param name="doc">XmlDocument</param>
        /// <param name="count">����λ��</param>
        /// <returns>XmlDocument</returns>
        XmlDocument EncryptXmlDoc2XmlDoc(XmlDocument doc, int count);

        /// <summary>
        /// ����XmlDocument��������XmlDocument
        /// </summary>
        /// <param name="doc">XmlDocument</param>
        /// <param name="count">����λ��</param>
        /// <returns>XmlDocument</returns>
        XmlDocument DecrypXmlDoc2XmlDoc(XmlDocument doc, int count);

        /// <summary>
        /// ����XML�ļ�
        /// </summary>
        /// <param name="path">����xml�ļ���·��(�����ļ���)</param>
        /// <param name="textContent">xml�ļ��ı�������</param>
        void SaveXml(string xmlpath, string textContent);
    }
}