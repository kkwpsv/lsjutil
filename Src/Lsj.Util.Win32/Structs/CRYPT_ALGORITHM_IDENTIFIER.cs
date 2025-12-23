using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="CRYPT_ALGORITHM_IDENTIFIER"/> structure specifies an algorithm used to encrypt a private key.
    /// The structure includes the object identifier (OID) of the algorithm and any needed parameters for that algorithm.
    /// The parameters contained in its <see cref="CRYPT_OBJID_BLOB"/> are encoded.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_algorithm_identifier"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CRYPT_ALGORITHM_IDENTIFIER
    {
        /// <summary>
        /// <para>
        /// An OID of an algorithm.
        /// This member can be one of the following values.
        /// This list is only representative.
        /// New algorithms are being defined by various users.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549"
        /// </para>
        /// </term>
        /// <term>
        /// Root object identifier for the RSA asymmetric encryption algorithm family. RSA stands for Ron Rivest, Adi Shamir and Leonard Adleman, the mathematicians who invented the algorithm. This is a popular asymmetric algorithm that can be used for encryption or signing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_PKCS"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1"
        /// </para>
        /// </term>
        /// <term>
        /// Root object identifier for the PKCS (Public Key Cryptography Standards) group of standards that define public key or asymmetric cryptography.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_HASH"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.2"
        /// </para>
        /// </term>
        /// <term>
        /// RSA signing (encryption) algorithm that uses a hashing algorithm to hash the content before signing it.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_ENCRYPT"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.3"
        /// </para>
        /// </term>
        /// <term>
        /// RSA encryption algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_PKCS_1"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.1"
        /// </para>
        /// </term>
        /// <term>
        /// PKCS#1 is the first Public Key Cryptography Standard (PKCS) published by RSA Laboratories. The PKCS#1 standard defines the properties of encryption and decryption employed by the RSA algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_PKCS_2"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.2"
        /// </para>
        /// </term>
        /// <term>
        /// PKCS#2 was a Public Key Cryptography Standard (PKCS) that dealt with RSA encryption of message digests. It has been merged into PKCS#1.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_PKCS_3"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.3"
        /// </para>
        /// </term>
        /// <term>
        /// PKCS#3 is a Public Key Cryptography Standard (PKCS) that defines the Diffie-Hellman key agreement protocol.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_PKCS_4"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.4"
        /// </para>
        /// </term>
        /// <term>
        /// PKCS#4 was a Public Key Cryptography Standard (PKCS) that defined the RSA key syntax. It has been merged into PKCS#1.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_PKCS_5"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.5"
        /// </para>
        /// </term>
        /// <term>
        /// PKCS#5 is a Public Key Cryptography Standard (PKCS) that provides recommendations for the implementation of password-based cryptography. It covers key derivation functions, encryption schemes, message-authentication schemes, and ASN.1 syntax structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_PKCS_6"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.6"
        /// </para>
        /// </term>
        /// <term>
        /// PKCS#6 is a Public Key Cryptography Standard (PKCS) that describes the syntax for extended certificate information, a set of attributes that provides additional information about the entity whose public key is certified in the X.509 certificate.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_PKCS_7"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.7"
        /// </para>
        /// </term>
        /// <term>
        /// PKCS#7 is a Public Key Cryptography Standard (PKCS) that describes the general types of content to which cryptography can be applied. This includes data, signed data, enveloped data, signed-and-enveloped data, digested data, and encrypted data.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_PKCS_8"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.8"
        /// </para>
        /// </term>
        /// <term>
        /// PKCS#8 is a Public Key Cryptography Standard (PKCS) that defines the syntax for private key information in the <see cref="PrivateKeyInfo"/> ASN.1 type.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_PKCS_9"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9"
        /// </para>
        /// </term>
        /// <term>
        /// PKCS#8 is a Public Key Cryptography Standard (PKCS) that defines attribute types for use in PKCS#6 extended certificates, PKCS#7 digitally signed messages, PKCS#8 private-key information, and PKCS#10 certificate-signing requests.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_PKCS_10"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.10"
        /// </para>
        /// </term>
        /// <term>
        /// PKCS#10 is a Public Key Cryptography Standard (PKCS) that describes the certificate request syntax.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_PKCS_12"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.12"
        /// </para>
        /// </term>
        /// <term>
        /// PKCS#12 is a Public Key Cryptography Standard (PKCS) that describes the personal information exchange (PFX) format used to transfer personal identity information such as private keys and certificates.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_MD2"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.2.2"
        /// </para>
        /// </term>
        /// <term>
        /// RSA algorithm coupled with an MD2 message digest algorithm that hashes the message contents before signing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_MD4"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.2.4"
        /// </para>
        /// </term>
        /// <term>
        /// RSA algorithm coupled with an MD4 message digest algorithm that hashes the message contents before signing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_MD5"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.2.5"
        /// </para>
        /// </term>
        /// <term>
        /// RSA algorithm coupled with an MD5 message digest algorithm that hashes the message contents before signing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_RSA"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.1.1"
        /// </para>
        /// </term>
        /// <term>
        /// RSA is used to both encrypt and sign content.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_MD2RSA"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.1.2"
        /// </para>
        /// </term>
        /// <term>
        /// RSA is used to encrypt the content and to sign the content hash created by using the MD2 message digest algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_MD4RSA"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.1.3"
        /// </para>
        /// </term>
        /// <term>
        /// RSA is used to encrypt the content and to sign the content hash created by using the MD4 message digest algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_MD5RSA"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.1.4"
        /// </para>
        /// </term>
        /// <term>
        /// RSA is used to encrypt the content and to sign the content hash created by using the MD5 message digest algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_SHA1RSA"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.1.5"
        /// </para>
        /// </term>
        /// <term>
        /// RSA is used to encrypt the content and to sign the content hash created by using the Secure Hashing Algorithm (SHA) algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_SETOAEP_RSA"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.1.6"
        /// </para>
        /// </term>
        /// <term>
        /// RSA that uses Optimal Asymmetric Encryption Padding (OAEP) encoding.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSAES_OAEP"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.1.7"
        /// </para>
        /// </term>
        /// <term>
        /// Public-key encryption scheme combining Optimal Asymmetric Encryption Padding (OAEP) with the RSAEP encryption primitive. RSAES-OAEP takes a plaintext as input, transforms it into an encoded message by using OAEP and applies RSAEP to the result using the RSA public key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_MGF1"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.1.8"
        /// </para>
        /// </term>
        /// <term>
        /// RSA algorithm that uses the mask generator function (MGF1)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_PSPECIFIED"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.1.9"
        /// </para>
        /// </term>
        /// <term>
        /// RSA algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_SSA_PSS"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.1.10"
        /// </para>
        /// </term>
        /// <term>
        /// RSA algorithm that uses the probabilistic signature scheme (PSS).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_SHA256RSA"/>
        /// </para>
        /// <para>
        /// 1.2.840.113549.1.1.11
        /// </para>
        /// </term>
        /// <term>
        /// RSA is used to encrypt the content and to sign the hash created by using the Secure Hashing Algorithm 256 (SHA256) algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_SHA384RSA"/>
        /// </para>
        /// <para>
        /// 1.2.840.113549.1.1.12
        /// </para>
        /// </term>
        /// <term>
        /// RSA is used to encrypt the content and to sign the hash created by using the Secure Hashing Algorithm 384 (SHA384) algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_SHA512RSA"/>
        /// </para>
        /// <para>
        /// 1.2.840.113549.1.1.13
        /// </para>
        /// </term>
        /// <term>
        /// RSA is used to encrypt the content and to sign the hash created by using the Secure Hashing Algorithm 512 (SHA512) algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_DH"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.3.1"
        /// </para>
        /// </term>
        /// <term>
        /// RSA algorithm combined with the Diffie-Hellman key exchange algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_data"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.7.1"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied over the PKCS#7 ASN.1 Data type.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_signedData"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.7.2"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied over the PKCS#7 ASN.1 <see cref="SignedData"/> type.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_envelopedData"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.7.3"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied over the PKCS#7 ASN.1 <see cref="EnvelopedData"/> type.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_signEnvData"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.7.4"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied over the PKCS#7 ASN.1 <see cref="SignedAndEnvelopedData"/> type.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_digestedData"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.7.5"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied over the PKCS#7 ASN.1 <see cref="DigestedData"/> type.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_hashedData"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.7.5"
        /// </para>
        /// </term>
        /// <term>
        /// RSA algorithm applied to hashed data.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_encryptedData"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.7.6"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied over the PKCS#7 ASN.1 <see cref="EncryptedData"/> type.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_emailAddr"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.1"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to the to an ASN.1 email address.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_unstructName"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.2"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to the an ASN.1 unstructured name.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_contentType"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.3"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to the ASN.1 content type value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_messageDigest"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.4"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to a message digest.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_signingTime"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.5"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to the signing date and time value
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_counterSign"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.6"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to the counter signature.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_challengePwd"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.7"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to a challenge password.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_unstructAddr"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.8"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to an unstructured address.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_extCertAttrs"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.9"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to the certificate attributes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_certExtensions"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.14"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to certificate extensions.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_SMIMECapabilities"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.15"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to the Multipurpose Internet Mail Extensions (MIME)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_preferSignedData"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.15.1"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to the SMIME preferSignedData capability preference.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_TIMESTAMP_TOKEN"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.16.1.4"
        /// </para>
        /// </term>
        /// <term>
        /// Timestamp object identifier.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RFC3161_counterSign"/>
        /// </para>
        /// <para>
        /// "1.3.6.1.4.1.311.3.3.1"
        /// </para>
        /// </term>
        /// <term>
        /// Counter signature of a signature.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_SMIMEalg"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.16.3"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to the Multipurpose Internet Mail Extensions (MIME) algorithm. SMIME reports the decryption capabilities of an email recipient to an email sender so that the sender can choose the most secure algorithm supported by both parties.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_SMIMEalgESDH"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.16.3.5"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to the specified SMIME ESDH algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_SMIMEalgCMS3DESwrap"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.16.3.6"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to the SMIME algorithm. Triple DES is used for key wrapping.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_SMIMEalgCMSRC2wrap"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.9.16.3.7"
        /// </para>
        /// </term>
        /// <term>
        /// RSA applied to the SMIME algorithm. RC2 is used for key wrapping.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_RC2CBC"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.3.2"
        /// </para>
        /// </term>
        /// <term>
        /// RSA that uses the Rivest Cipher (RC2) block cipher algorithm coupled with a cipher-block chaining mode of operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_RC4"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.3.4"
        /// </para>
        /// </term>
        /// <term>
        /// RSA that uses the Rivest Cipher (RC4) block cipher algorithm coupled with a cipher-block chaining mode of operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_DES_EDE3_CBC"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.3.7"
        /// </para>
        /// </term>
        /// <term>
        /// RSA that uses the triple Data Encryption Standard (DES) algorithm coupled with a cipher-block chaining mode of operation. The encryption operation is performed as encrypt-decrypt-encrypt.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_RC5_CBCPad"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.3.9"
        /// </para>
        /// </term>
        /// <term>
        /// RSA that uses the Rivest Cipher (RC5) block cipher algorithm coupled with a cipher-block chaining pad mode of operation
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_ANSI_x942"/>
        /// </para>
        /// <para>
        /// "1.2.840.10046"
        /// </para>
        /// </term>
        /// <term>
        /// Root object identifier for the ANSI X942 standard.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_ANSI_x942_DH"/>
        /// </para>
        /// <para>
        /// "1.2.840.10046.2.1"
        /// </para>
        /// </term>
        /// <term>
        /// Diffie-Hellman Key Exchange Algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_X957"/>
        /// </para>
        /// <para>
        /// "1.2.840.10040"
        /// </para>
        /// </term>
        /// <term>
        /// Root object identifier for the X957 standard.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_X957_DSA"/>
        /// </para>
        /// <para>
        /// "1.2.840.10040.4.1"
        /// </para>
        /// </term>
        /// <term>
        /// Digital Signature Algorithm (DSA).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_X957_SHA1DSA"/>
        /// </para>
        /// <para>
        /// "1.2.840.10040.4.3"
        /// </para>
        /// </term>
        /// <term>
        /// Digital Signature Algorithm (DSA) coupled with the Secure Hashing Algorithm (SHA) algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_ECC_PUBLIC_KEY"/>
        /// </para>
        /// <para>
        /// "1.2.840.10045.2.1"
        /// </para>
        /// </term>
        /// <term>
        /// Elliptic curve public key cryptography.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_ECC_CURVE_P256"/>
        /// </para>
        /// <para>
        /// "1.2.840.10045.3.1.7"
        /// </para>
        /// </term>
        /// <term>
        /// 256 bit elliptic curve.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_ECC_CURVE_P384"/>
        /// </para>
        /// <para>
        /// "1.3.132.0.34"
        /// </para>
        /// </term>
        /// <term>
        /// 384 bit elliptic curve.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_ECC_CURVE_P521"/>
        /// </para>
        /// <para>
        /// "1.3.132.0.35"
        /// </para>
        /// </term>
        /// <term>
        /// 512 bit elliptic curve.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_ECDSA_SHA1"/>
        /// </para>
        /// <para>
        /// "1.2.840.10045.4.1"
        /// </para>
        /// </term>
        /// <term>
        /// Elliptic curve Digital Signature Algorithm (DSA) coupled with the Secure Hashing Algorithm (SHA) algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_ECDSA_SPECIFIED"/>
        /// </para>
        /// <para>
        /// "1.2.840.10045.4.3"
        /// </para>
        /// </term>
        /// <term>
        /// Elliptic curve Digital Signature Algorithm (DSA).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_ECDSA_SHA256"/>
        /// </para>
        /// <para>
        /// "1.2.840.10045.4.3.2"
        /// </para>
        /// </term>
        /// <term>
        /// Elliptic curve Digital Signature Algorithm (DSA) coupled with the Secure Hashing Algorithm (SHA256) algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_ECDSA_SHA384"/>
        /// </para>
        /// <para>
        /// "1.2.840.10045.4.3.3"
        /// </para>
        /// </term>
        /// <term>
        /// Elliptic curve Digital Signature Algorithm (DSA) coupled with the Secure Hashing Algorithm (SHA384) algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_ECDSA_SHA512"/>
        /// </para>
        /// <para>
        /// "1.2.840.10045.4.3.4"
        /// </para>
        /// </term>
        /// <term>
        /// Elliptic curve Digital Signature Algorithm (DSA) coupled with the Secure Hashing Algorithm (SHA512) algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NO_HASH"/>
        /// </para>
        /// <para>
        /// "1.3.6.1.4.1.311.73.1"
        /// </para>
        /// </term>
        /// <term>
        /// An OID that indicates that no hash algorithm is used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_AES128_CBC"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.1.2"
        /// </para>
        /// </term>
        /// <term>
        /// 128 bit Advanced Encryption Standard (AES) algorithm with cipher-block chaining mode of operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_AES192_CBC"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.1.22"
        /// </para>
        /// </term>
        /// <term>
        /// 192 bit Advanced Encryption Standard (AES) algorithm with cipher-block chaining mode of operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_AES256_CBC"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.1.42"
        /// </para>
        /// </term>
        /// <term>
        /// 256 bit Advanced Encryption Standard (AES) algorithm with cipher-block chaining mode of operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_AES128_WRAP"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.1.5"
        /// </para>
        /// </term>
        /// <term>
        /// 128 bit Advanced Encryption Standard (AES) algorithm used for key wrapping.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_AES192_WRAP"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.1.25"
        /// </para>
        /// </term>
        /// <term>
        /// 192 bit Advanced Encryption Standard (AES) algorithm used for key wrapping.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_AES256_WRAP"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.1.45"
        /// </para>
        /// </term>
        /// <term>
        /// 256 bit Advanced Encryption Standard (AES) algorithm used for key wrapping.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// szOID_DATA STRUCTURE
        /// </para>
        /// <para>
        /// "1.2.840.10040.4.3"
        /// </para>
        /// </term>
        /// <term>
        /// Unspecified data structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_DH_SINGLE_PASS_STDDH_SHA1_KDF"/>
        /// </para>
        /// <para>
        /// "1.3.133.16.840.63.0.2"
        /// </para>
        /// </term>
        /// <term>
        /// Single pass SHA1 key derivation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_DH_SINGLE_PASS_STDDH_SHA256_KDF"/>
        /// </para>
        /// <para>
        /// "1.3.132.1.11.1"
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Single pass SHA256 key derivation.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:This OID is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_DH_SINGLE_PASS_STDDH_SHA384_KDF"/>
        /// </para>
        /// <para>
        /// "1.3.132.1.11.2"
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Single pass SHA384 key derivation.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:This OID is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_DS"/>
        /// </para>
        /// <para>
        /// "2.5"
        /// </para>
        /// </term>
        /// <term>
        /// Enveloped signature.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_DSALG"/>
        /// </para>
        /// <para>
        /// "2.5.8"
        /// </para>
        /// </term>
        /// <term>
        /// Enveloped digital signature algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_DSALG_CRPT"/>
        /// </para>
        /// <para>
        /// "2.5.8.1"
        /// </para>
        /// </term>
        /// <term>
        /// Digital signature algorithm applied to encrypted content.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_DSALG_HASH"/>
        /// </para>
        /// <para>
        /// "2.5.8.2"
        /// </para>
        /// </term>
        /// <term>
        /// Digital signature algorithm applied to hashed content.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_DSALG_SIGN"/>
        /// </para>
        /// <para>
        /// "2.5.8.3"
        /// </para>
        /// </term>
        /// <term>
        /// Digital signature algorithm applied to a signature.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_DSALG_RSA"/>
        /// </para>
        /// <para>
        /// "2.5.8.1.1"
        /// </para>
        /// </term>
        /// <term>
        /// Enveloped digital signature algorithm applied to RSA encrypted or signed content.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIW"/>
        /// </para>
        /// <para>
        /// "1.3.14"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) root object identifier.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security standard root object identifier.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_md4RSA"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.2"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security RSA algorithm applied to a hash created by using the Message Digest (MD4) algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_md5RSA"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.3"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security RSA algorithm applied to a hash created by using the Message Digest (MD5) algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_md4RSA2"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.4"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security RSA2 algorithm applied to a hash created by using the Message Digest (MD5) algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_desECB"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.6"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security Data Encryption Standard (DES) algorithm coupled with a electronic codebook mode of operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_desCBC"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.7"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security Data Encryption Standard (DES) algorithm coupled with a cipher-block chaining mode of operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_desOFB"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.8"
        /// </para>
        /// </term>
        /// <term>
        /// Data Encryption Standard (DES) algorithm coupled with a cipher-block chaining mode of operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_desCFB"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.9"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security Data Encryption Standard (DES) algorithm coupled with a output feedback mode of operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_desMAC"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.10"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security Data Encryption Standard (DES) algorithm coupled with a message authentication code (MAC) that hashes both the pre-image and the key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_rsaSign"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.11"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security RSA signature algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_dsa"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.12"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security Digital Signature Algorithm (DSA).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_shaDSA"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.13"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security Digital Signature Algorithm (DSA) that uses the Secure Hashing Algorithm (SHA) to hash the message contents.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_mdc2RSA"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.14"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security RSA algorithm that uses the Modification Detection Code 2 (MDC2) or Meyer-Schilling hash function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_shaRSA"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.15"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security RSA algorithm coupled with the Secure Hashing Algorithm (SHA).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_dhCommMod"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.16"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security Diffie-Hellman key exchange algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_desEDE"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.17"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security Data Encryption Standard (DES) algorithm coupled with the encrypt-decrypt-encrypt (EDE) multiple encryption mode of operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_sha"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.18"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security Secure Hashing Algorithm (SHA).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_mdc2"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.19"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security Modification Detection Code 2 (MDC2) or Meyer-Schilling hash function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_dsaComm"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.20"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security Digital Signature Algorithm (DSA).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_dsaCommSHA"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.21"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security Digital Signature Algorithm (DSA) coupled with the Secure Hashing Algorithm (SHA).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_rsaXchg"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.22"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security RSA algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_keyHashSeal"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.23"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security hashing algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_md2RSASign"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.24"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security RSA algorithm coupled with the Message Digest (MD2) hashing algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_md5RSASign"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.25"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security RSA algorithm coupled with the Message Digest (MD5) hashing algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_sha1"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.26"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security Secure Hashing (SHA1) algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_dsaSHA1"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.27"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security Digital Signature Algorithm (DSA) that uses the Secure Hashing Algorithm 1 (SHA1).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_dsaCommSHA1"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.28"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security Digital Signature Algorithm (DSA) that uses the Secure Hashing Algorithm 1 (SHA1).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWSEC_sha1RSASign"/>
        /// </para>
        /// <para>
        /// "1.3.14.3.2.29"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Security RSA algorithm that uses the Secure Hashing Algorithm 1 (SHA1).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWDIR"/>
        /// </para>
        /// <para>
        /// "1.3.14.7.2"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Directory root object identifier.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWDIR_CRPT"/>
        /// </para>
        /// <para>
        /// "1.3.14.7.2.1"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Directory generic encryption algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWDIR_HASH"/>
        /// </para>
        /// <para>
        /// "1.3.14.7.2.2"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Directory generic hashing algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWDIR_SIGN"/>
        /// </para>
        /// <para>
        /// "1.3.14.7.2.3"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Directory generic signing algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWDIR_md2"/>
        /// </para>
        /// <para>
        /// "1.3.14.7.2.2.1"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Directory Message digest (MD2) algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_OIWDIR_md2RSA"/>
        /// </para>
        /// <para>
        /// "1.3.14.7.2.3.1"
        /// </para>
        /// </term>
        /// <term>
        /// NIST OSE Implementors' Workshop (OIW) Directory RSA algorithm coupled with the Message digest (MD2) hashing algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1"
        /// </para>
        /// </term>
        /// <term>
        /// INFOSEC object identifier root.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_sdnsSignature"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.1"
        /// </para>
        /// </term>
        /// <term>
        /// Signature algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_mosaicSignature"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.2"
        /// </para>
        /// </term>
        /// <term>
        /// Signature algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_sdnsConfidentiality"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.3"
        /// </para>
        /// </term>
        /// <term>
        /// Encryption algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_mosaicConfidentiality"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.4"
        /// </para>
        /// </term>
        /// <term>
        /// Encryption algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_sdnsIntegrity"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.5"
        /// </para>
        /// </term>
        /// <term>
        /// Signing algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_mosaicIntegrity"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.6"
        /// </para>
        /// </term>
        /// <term>
        /// Signing algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_sdnsTokenProtection"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.7"
        /// </para>
        /// </term>
        /// <term>
        /// Secure Data Network System token encryption.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_mosaicTokenProtection"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.8"
        /// </para>
        /// </term>
        /// <term>
        /// Mosaic token encryption.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_sdnsKeyManagement"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.9"
        /// </para>
        /// </term>
        /// <term>
        /// Secure Data Network System key management.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_mosaicKeyManagement"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.10"
        /// </para>
        /// </term>
        /// <term>
        /// Mosaic key management.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_sdnsKMandSig"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.11"
        /// </para>
        /// </term>
        /// <term>
        /// Secure Data Network System key management and signature.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_mosaicKMandSig"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.12"
        /// </para>
        /// </term>
        /// <term>
        /// Mosaic key management and signature.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_SuiteASignature"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.13"
        /// </para>
        /// </term>
        /// <term>
        /// National Security Agency (NSA) Suite A Cryptography signature algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_SuiteAConfidentiality"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.14"
        /// </para>
        /// </term>
        /// <term>
        /// National Security Agency (NSA) Suite A Cryptography encryption algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_SuiteAIntegrity"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.15"
        /// </para>
        /// </term>
        /// <term>
        /// National Security Agency (NSA) Suite A Cryptography signature algorithm.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_SuiteATokenProtection"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.16"
        /// </para>
        /// </term>
        /// <term>
        /// National Security Agency (NSA) Suite A Cryptography security token encryption.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_SuiteAKeyManagement"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.17"
        /// </para>
        /// </term>
        /// <term>
        /// National Security Agency (NSA) Suite A Cryptography security key management.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_SuiteAKMandSig"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.18"
        /// </para>
        /// </term>
        /// <term>
        /// National Security Agency (NSA) Suite A Cryptography key management and signature.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_mosaicUpdatedSig"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.19"
        /// </para>
        /// </term>
        /// <term>
        /// Mosaic updated signature.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_mosaicKMandUpdSig"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.20"
        /// </para>
        /// </term>
        /// <term>
        /// Mosaic key management and updated signature.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_INFOSEC_mosaicUpdatedInteg"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.2.1.1.21"
        /// </para>
        /// </term>
        /// <term>
        /// Mosaic updated signature.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_sha256"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.2.1"
        /// </para>
        /// </term>
        /// <term>
        /// Secure hashing algorithm (SHA) that uses a 256 bit key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_sha384"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.2.2"
        /// </para>
        /// </term>
        /// <term>
        /// Secure hashing algorithm (SHA) that uses a 384 bit key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_sha512"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.2.3"
        /// </para>
        /// </term>
        /// <term>
        /// Secure hashing algorithm (SHA) that uses a 512 bit key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_shake128"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.2.11"
        /// </para>
        /// </term>
        /// <term>
        /// Secure hashing algorithm KECCAK (SHAKE) that uses a 128 bit key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_shake256"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.2.12"
        /// </para>
        /// </term>
        /// <term>
        /// Secure hashing algorithm KECCAK (SHAKE) that uses a 256 bit key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_ml_dsa_44"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.3.17"
        /// </para>
        /// </term>
        /// <term>
        /// "Pure" Module-Lattice-Based Digital Signature Algorithm (ML-DSA) that uses a 128 bit lattice.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_ml_dsa_65"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.3.18"
        /// </para>
        /// </term>
        /// <term>
        /// "Pure" Module-Lattice-Based Digital Signature Algorithm (ML-DSA) that uses a 192 bit lattice.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_ml_dsa_87"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.3.19"
        /// </para>
        /// </term>
        /// <term>
        /// "Pure" Module-Lattice-Based Digital Signature Algorithm (ML-DSA) that uses a 256 bit lattice.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_hash_ml_dsa_44_with_sha512"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.3.32"
        /// </para>
        /// </term>
        /// <term>
        /// "Pre-Hash" Module-Lattice-Based Digital Signature Algorithm (ML-DSA) that uses a 128 bit lattice.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_hash_ml_dsa_65_with_sha512"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.3.33"
        /// </para>
        /// </term>
        /// <term>
        /// "Pre-Hash" Module-Lattice-Based Digital Signature Algorithm (ML-DSA) that uses a 192 bit lattice.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_NIST_hash_ml_dsa_87_with_sha512"/>
        /// </para>
        /// <para>
        /// "2.16.840.1.101.3.4.3.34"
        /// </para>
        /// </term>
        /// <term>
        /// "Pre-Hash" Module-Lattice-Based Digital Signature Algorithm (ML-DSA) that uses a 256 bit lattice.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_PKIX_NO_SIGNATURE"/>
        /// </para>
        /// <para>
        /// "1.3.6.1.5.5.7.6.2"
        /// </para>
        /// </term>
        /// <term>
        /// No signature.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_RSA_SSA_PSS"/>
        /// </para>
        /// <para>
        /// "1.2.840.113549.1.1.10"
        /// </para>
        /// </term>
        /// <term>
        /// RSA Signature Scheme with Appendix and Probabilistic Signature Scheme.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="szOID_ECDSA_SPECIFIED"/>
        /// </para>
        /// <para>
        /// "1.2.840.10045.4.3"
        /// </para>
        /// </term>
        /// <term>
        /// Elliptic Curve Digital Signature Algorithm (ECDSA).
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public IntPtr pszObjId;

        /// <summary>
        /// <para>
        /// A BLOB that provides encoded algorithm-specific parameters.
        /// In many cases, there are no parameters.
        /// This is indicated by setting the <see cref="CRYPT_OBJID_BLOB.cbData"/> member of the <see cref="Parameters"/> BLOB to zero.
        /// </para>
        /// <para>
        /// The following algorithms have the specified encoded parameters. For more information, see Constants for CryptEncodeObject and CryptDecodeObject.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="szOID_OIWSEC_dsa"/>
        /// </term>
        /// <term>
        /// A <see cref="CERT_DSS_PARAMETERS"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="szOID_RSA_RC2CBC"/>
        /// </term>
        /// <term>
        /// A <see cref="CRYPT_RC2_CBC_PARAMETERS"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="szOID_OIWSEC_desCBC"/>
        /// </term>
        /// <term>
        /// A <see cref="CRYPT_DATA_BLOB"/> that contains an initialization vector in the form of an octet string.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="szOID_RSA_DES_EDE3_CBC"/>
        /// </term>
        /// <term>
        /// A <see cref="CRYPT_DATA_BLOB"/> that contains an initialization vector in the form of an octet string.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="szOID_RSA_RC4"/>
        /// </term>
        /// <term>
        /// A <see cref="CRYPT_DATA_BLOB"/> that contains an initialization vector in the form of an octet string.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="szOID_RSA_SSA_PSS"/>
        /// </term>
        /// <term>
        /// A <see cref="CRYPT_RSA_SSA_PSS_PARAMETERS"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="szOID_ECDSA_SPECIFIED"/>
        /// </term>
        /// <term>
        /// A <see cref="CRYPT_ALGORITHM_IDENTIFIER"/> structure.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public CRYPT_OBJID_BLOB Parameters;
    }
}
