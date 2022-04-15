using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAssetAPI;
using UAssetAPI.PropertyTypes;
using UAssetAPI.StructTypes;

namespace QueenIO.Structs
{
    public class PartsVisibilityByOuter
    {
        public string Name { get; set; }
        public string StructType { get; } = "STR_PartsVisibilityByOuter";
        public string InnerKey { get; set; } = string.Empty;
        public List<InnerPartsVisibility> InnerPartsVisibilityList { get; set; } = new List<InnerPartsVisibility>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Initialize">Initializes the sturct with all existing bloodveils</param>
        public PartsVisibilityByOuter(bool Initialize = false)
        {
            if (Initialize)
            {
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["DrapeA_Male"], OuterKey = "/Game/Costumes/Outers/Drape_Male1/Meshes/SK_Drape_Male1.SK_Drape_Male1" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["DrapeB_Male"], OuterKey = "/Game/Costumes/Outers/Drape_Male2/Meshes/SK_Drape_Male2.SK_Drape_Male2" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["DrapeC_Male"], OuterKey = "/Game/Costumes/Outers/Drape_Male3/Meshes/SK_Drape_Male3.SK_Drape_Male3" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["DrapeD_Male"], OuterKey = "/Game/Costumes/Outers/Drape_Male4/Meshes/SK_Drape_Male4.SK_Drape_Male4" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["DrapeE_Male"], OuterKey = "/Game/Costumes/Outers/Drape_Male5/Meshes/SK_Drape_Male5.SK_Drape_Male5" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["DrapeF_Male"], OuterKey = "/Game/Costumes/Outers/Drape_Male_Xmas/Meshes/SK_Drape_Male_Xmas.SK_Drape_Male_Xmas" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["GauntletA_Male"], OuterKey = "/Game/Costumes/Outers/Gauntlet_Male1/Meshes/SK_Gauntlet_Male1.SK_Gauntlet_Male1" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["GauntletC_Male"], OuterKey = "/Game/Costumes/Outers/Gauntlet_Male3/Meshes/SK_Gauntlet_Male3.SK_Gauntlet_Male3" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["GauntletE_Male"], OuterKey = "/Game/Costumes/Outers/Gauntlet_Male5/Meshes/SK_Gauntlet_Male5.SK_Gauntlet_Male5" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["GauntletF_Male"], OuterKey = "/Game/Costumes/Outers/Gauntlet_Male6/Meshes/SK_Gauntlet_Male6.SK_Gauntlet_Male6" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["GauntletH_Male"], OuterKey = "/Game/Costumes/Outers/Gauntlet_Male8/Meshes/SK_Gauntlet_Male8.SK_Gauntlet_Male8" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["GauntletI_Male"], OuterKey = "/Game/Costumes/Outers/Gauntlet_Male9/Meshes/SK_Gauntlet_Male9.SK_Gauntlet_Male9" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["GauntletJ_Male"], OuterKey = "/Game/Costumes/Outers/Gauntlet_Male_Xmas/Meshes/SK_Gauntlet_Male_Xmas.SK_Gauntlet_Male_Xmas" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["LongcoatA_Male"], OuterKey = "/Game/Costumes/Outers/Longcoat_Male1/Meshes/SK_Longcoat_Male1.SK_Longcoat_Male1" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["LongcoatB_Male"], OuterKey = "/Game/Costumes/Outers/Longcoat_Male2/Meshes/SK_Longcoat_Male2.SK_Longcoat_Male2" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["LongcoatD_Male"], OuterKey = "/Game/Costumes/Outers/Longcoat_Male4/Meshes/SK_Longcoat_Male4.SK_Longcoat_Male4" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["LongcoatE_Male"], OuterKey = "/Game/Costumes/Outers/Longcoat_Male5/Meshes/SK_Longcoat_Male5.SK_Longcoat_Male5" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["LongcoatH_Male"], OuterKey = "/Game/Costumes/Outers/Longcoat_Male8/Meshes/SK_Longcoat_Male8.SK_Longcoat_Male8" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["LongcoatI_Male"], OuterKey = "/Game/Costumes/Outers/Longcoat_Male_Xmas/Meshes/SK_Longcoat_Male_Xmas.SK_Longcoat_Male_Xmas" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["MufflerA_Male"], OuterKey = "/Game/Costumes/Outers/Muffler_Male1/Meshes/SK_Muffler_Male1.SK_Muffler_Male1" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["MufflerC_Male"], OuterKey = "/Game/Costumes/Outers/Muffler_Male3/Meshes/SK_Muffler_Male3.SK_Muffler_Male3" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["MufflerD_Male"], OuterKey = "/Game/Costumes/Outers/Muffler_Male4/Meshes/SK_Muffler_Male4.SK_Muffler_Male4" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["MufflerE_Male"], OuterKey = "/Game/Costumes/Outers/Muffler_Male5/Meshes/SK_Muffler_Male5.SK_Muffler_Male5" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["MufflerF_Male"], OuterKey = "/Game/Costumes/Outers/Muffler_Male6/Meshes/SK_Muffler_Male6.SK_Muffler_Male6" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["MufflerG_Male"], OuterKey = "/Game/Costumes/Outers/Muffler_Male_Xmas/Meshes/SK_Muffler_Male_Xmas.SK_Muffler_Male_Xmas" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["DrapeA_Female"], OuterKey = "/Game/Costumes/Outers/Drape_Female1/Meshes/SK_Drape_Female1.SK_Drape_Female1" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["DrapeB_Female"], OuterKey = "/Game/Costumes/Outers/Drape_Female2/Meshes/SK_Drape_Female2.SK_Drape_Female2" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["DrapeC_Female"], OuterKey = "/Game/Costumes/Outers/Drape_Female3/Meshes/SK_Drape_Female3.SK_Drape_Female3" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["DrapeD_Female"], OuterKey = "/Game/Costumes/Outers/Drape_Female4/Meshes/SK_Drape_Female4.SK_Drape_Female4" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["DrapeE_Female"], OuterKey = "/Game/Costumes/Outers/Drape_Female5/Meshes/SK_Drape_Female5.SK_Drape_Female5" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["DrapeF_Female"], OuterKey = "/Game/Costumes/Outers/Drape_Female_Xmas/Meshes/SK_Drape_Female_Xmas.SK_Drape_Female_Xmas" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["GauntletA_Female"], OuterKey = "/Game/Costumes/Outers/Gauntlet_Female1/Meshes/SK_Gauntlet_Female1.SK_Gauntlet_Female1" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["GauntletC_Female"], OuterKey = "/Game/Costumes/Outers/Gauntlet_Female3/Meshes/SK_Gauntlet_Female3.SK_Gauntlet_Female3" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["GauntletE_Female"], OuterKey = "/Game/Costumes/Outers/Gauntlet_Female5/Meshes/SK_Gauntlet_Female5.SK_Gauntlet_Female5" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["GauntletF_Female"], OuterKey = "/Game/Costumes/Outers/Gauntlet_Female6/Meshes/SK_Gauntlet_Female6.SK_Gauntlet_Female6" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["GauntletH_Female"], OuterKey = "/Game/Costumes/Outers/Gauntlet_Female8/Meshes/SK_Gauntlet_Female8.SK_Gauntlet_Female8" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["GauntletI_Female"], OuterKey = "/Game/Costumes/Outers/Gauntlet_Female9/Meshes/SK_Gauntlet_Female9.SK_Gauntlet_Female9" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["GauntletJ_Female"], OuterKey = "/Game/Costumes/Outers/Gauntlet_Female_Xmas/Meshes/SK_Gauntlet_Female_Xmas.SK_Gauntlet_Female_Xmas" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["LongcoatA_Female"], OuterKey = "/Game/Costumes/Outers/Longcoat_Female1/Meshes/SK_Longcoat_Female1.SK_Longcoat_Female1" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["LongcoatB_Female"], OuterKey = "/Game/Costumes/Outers/Longcoat_Female2/Meshes/SK_Longcoat_Female2.SK_Longcoat_Female2" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["LongcoatD_Female"], OuterKey = "/Game/Costumes/Outers/Longcoat_Female4/Meshes/SK_Longcoat_Female4.SK_Longcoat_Female4" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["LongcoatE_Female"], OuterKey = "/Game/Costumes/Outers/Longcoat_Female5/Meshes/SK_Longcoat_Female5.SK_Longcoat_Female5" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["LongcoatH_Female"], OuterKey = "/Game/Costumes/Outers/Longcoat_Female8/Meshes/SK_Longcoat_Female8.SK_Longcoat_Female8" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["LongcoatI_Female"], OuterKey = "/Game/Costumes/Outers/Longcoat_Female_Xmas/Meshes/SK_Longcoat_Female_Xmas.SK_Longcoat_Female_Xmas" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["MufflerA_Female"], OuterKey = "/Game/Costumes/Outers/Muffler_Female1/Meshes/SK_Muffler_Female1.SK_Muffler_Female1" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["MufflerC_Female"], OuterKey = "/Game/Costumes/Outers/Muffler_Female3/Meshes/SK_Muffler_Female3.SK_Muffler_Female3" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["MufflerD_Female"], OuterKey = "/Game/Costumes/Outers/Muffler_Female4/Meshes/SK_Muffler_Female4.SK_Muffler_Female4" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["MufflerE_Female"], OuterKey = "/Game/Costumes/Outers/Muffler_Female5/Meshes/SK_Muffler_Female5.SK_Muffler_Female5" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["MufflerF_Female"], OuterKey = "/Game/Costumes/Outers/Muffler_Female6/Meshes/SK_Muffler_Female6.SK_Muffler_Female6" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["MufflerG_Female"], OuterKey = "/Game/Costumes/Outers/Muffler_Female_Xmas/Meshes/SK_Muffler_Female_Xmas.SK_Muffler_Female_Xmas" });
                InnerPartsVisibilityList.Add(new InnerPartsVisibility() { Name = NameToKey["GauntletInvisible"], OuterKey = "/Game/BasicAssets/Meshes/SK_Null.SK_Null" });
            }
        }

        public static Dictionary<string, string> NameToKey = new Dictionary<string, string>()
        {
            {"InnerKey", "InnerKey_186_FAD54D3E48EA33029A60DEB307CABA12"},
            {"DrapeA_Male", "DrapeA_Male_80_B78F08694176B634F5EBBA9F549C8B01"},
            {"DrapeB_Male", "DrapeB_Male_81_ACF24D6C4FF04FAC28B1A682E239E6FF"},
            {"DrapeC_Male", "DrapeC_Male_82_9F3DF67545D8C31800F76AB4AE50FD41"},
            {"DrapeD_Male", "DrapeD_Male_83_33B05C33473A0AB3D000DBBE0F506D3C"},
            {"DrapeE_Male", "DrapeE_Male_84_F49D70AE48215743CA0E94B3BE95AF31"},
            {"DrapeF_Male", "DrapeF_Male_206_C2D710D84D8FB3224C735EB1D37A302A"},
            {"GauntletA_Male", "GauntletA_Male_85_64C72D1C4088E7E1B587239215755F9C"},
            {"GauntletC_Male", "GauntletC_Male_86_CD80455C488B3F45C364FF857AC22936"},
            {"GauntletE_Male", "GauntletE_Male_87_55286EEE4911BE05C6B64CB59523CE8C"},
            {"GauntletF_Male", "GauntletF_Male_88_9A1AF8794A7A55C92D13F0814DF61A40"},
            {"GauntletH_Male", "GauntletH_Male_89_8BA9B8A84D55BDF84356D9BE162FC69C"},
            {"GauntletI_Male", "GauntletI_Male_184_57EA2BD349D261A5DB7D32963105B5C0"},
            {"GauntletJ_Male", "GauntletJ_Male_207_1931C6674DE9EB724D29E1AAD3583411"},
            {"LongcoatA_Male", "LongcoatA_Male_90_AD8B4EE143AD76E10D4B8688D876BC5D"},
            {"LongcoatB_Male", "LongcoatB_Male_91_E0EDF82041AF292E1023F1877D45BFFD"},
            {"LongcoatD_Male", "LongcoatD_Male_92_1FCB70FD4263437181A3819047163B08"},
            {"LongcoatE_Male", "LongcoatE_Male_93_84F3489247101AB32BA7ECBE5B101D04"},
            {"LongcoatH_Male", "LongcoatH_Male_94_6767DE5A400777425E35768A854709A3"},
            {"LongcoatI_Male", "LongcoatI_Male_208_4A8DEE0F48763BBCE94124BD3DDAE327"},
            {"MufflerA_Male", "MufflerA_Male_95_EE91F3F640874D8C89C5569042488511"},
            {"MufflerC_Male", "MufflerC_Male_96_4644BC864CEAC1D34373119603E7AEE2"},
            {"MufflerD_Male", "MufflerD_Male_97_C16F0FD24FA79FE096041CA10EC219AB"},
            {"MufflerE_Male", "MufflerE_Male_98_0DB76CF842A18DB8F548B0BF463C7931"},
            {"MufflerF_Male", "MufflerF_Male_99_1BB5705C44080AA794E4F7B6BB10F7C4"},
            {"MufflerG_Male", "MufflerG_Male_209_40856F7648146D3A8EE53B839D98106D"},
            {"DrapeA_Female", "DrapeA_Female_160_C4D666BD45DB647455B420970FF43618"},
            {"DrapeB_Female", "DrapeB_Female_161_DEB0E0DF46EFFA5EA5200888A82C4A6A"},
            {"DrapeC_Female", "DrapeC_Female_162_05BF3D6C4E2B5CB5916D68AE93126204"},
            {"DrapeD_Female", "DrapeD_Female_163_7B85C93B41FB4DE0C0A996A4AD71B321"},
            {"DrapeE_Female", "DrapeE_Female_164_D13646234DDBC40137E6CC8627C0EA01"},
            {"DrapeF_Female", "DrapeF_Female_210_2C5FF0FF45239FC90B84A48ADEF202CB"},
            {"GauntletA_Female", "GauntletA_Female_165_FE229D8641EB7EEA12D19884E6E9C56E"},
            {"GauntletC_Female", "GauntletC_Female_166_FFD837B5438C841AFD8237AE395E3E33"},
            {"GauntletE_Female", "GauntletE_Female_167_EAAE751C4BC90F46A2D890B9943911AD"},
            {"GauntletF_Female", "GauntletF_Female_168_AF89B0324D493CF45894CC93AC8B0F04"},
            {"GauntletH_Female", "GauntletH_Female_169_12FB5C0D44668FB3E9432099DB90AD6E"},
            {"GauntletI_Female", "GauntletI_Female_185_A9DC00FA4B1FFB7D6BCA43A7F85FB713"},
            {"GauntletJ_Female", "GauntletJ_Female_211_B8D39F8748C0B301DD0B57973E33D2C4"},
            {"LongcoatA_Female", "LongcoatA_Female_170_BCFA903D47C333784F8DE5800A555FF8"},
            {"LongcoatB_Female", "LongcoatB_Female_171_F79C617349924A761B3E618FDF95417A"},
            {"LongcoatD_Female", "LongcoatD_Female_172_27BD97FD4F9F6AB064D32E8633714C7B"},
            {"LongcoatE_Female", "LongcoatE_Female_173_0B77B8DE4F280DDFEF75F3966A8F4988"},
            {"LongcoatH_Female", "LongcoatH_Female_174_728C335949BF376E01FAEFB3972646A6"},
            {"LongcoatI_Female", "LongcoatI_Female_212_3B5566804AADE01FDFB6FAA07D3BFDC3"},
            {"MufflerA_Female", "MufflerA_Female_175_7EBDD4574BEF5E978F839E8CD8DC0825"},
            {"MufflerC_Female", "MufflerC_Female_176_4FD06BB045973199868B9CA28340EDFF"},
            {"MufflerD_Female", "MufflerD_Female_177_EC0ECACE4EE72CFB07FF22BA0E3CDAE4"},
            {"MufflerE_Female", "MufflerE_Female_178_E74137E84026A622F1B8629E81BD3B89"},
            {"MufflerF_Female", "MufflerF_Female_179_8A85B6264B5DC00F7D7E0183109598BF"},
            {"MufflerG_Female", "MufflerG_Female_213_847BA24A4937103F37A24A80BB67E6CC"},
            {"GauntletInvisible", "GauntletInvisible_189_B9F4FEB24A890275F93457AC7E2724F4"},
        };

        public static Dictionary<string, string> KeyToName = new Dictionary<string, string>()
        {
            {"InnerKey_186_FAD54D3E48EA33029A60DEB307CABA12", "InnerKey"},
            {"DrapeA_Male_80_B78F08694176B634F5EBBA9F549C8B01", "Night Fang Male"},
            {"DrapeB_Male_81_ACF24D6C4FF04FAC28B1A682E239E6FF", "Blue Hounds Male"},
            {"DrapeC_Male_82_9F3DF67545D8C31800F76AB4AE50FD41", "GXL Defender Male"},
            {"DrapeD_Male_83_33B05C33473A0AB3D000DBBE0F506D3C", "Hedgehog Fort Male"},
            {"DrapeE_Male_84_F49D70AE48215743CA0E94B3BE95AF31", "White Vestment Male"},
            {"DrapeF_Male_206_C2D710D84D8FB3224C735EB1D37A302A", "Festive Fang Male"},
            {"GauntletA_Male_85_64C72D1C4088E7E1B587239215755F9C", "Night Claw Male"},
            {"GauntletC_Male_86_CD80455C488B3F45C364FF857AC22936", "Noble Silver Male"},
            {"GauntletE_Male_87_55286EEE4911BE05C6B64CB59523CE8C", "GXM Variant Male"},
            {"GauntletF_Male_88_9A1AF8794A7A55C92D13F0814DF61A40", "Blackblood Liberator Male"},
            {"GauntletH_Male_89_8BA9B8A84D55BDF84356D9BE162FC69C", "Queenslayer Claw Male"},
            {"GauntletI_Male_184_57EA2BD349D261A5DB7D32963105B5C0", "Venous Claw Male"},
            {"GauntletJ_Male_207_1931C6674DE9EB724D29E1AAD3583411", "Festive Claw Male"},
            {"LongcoatA_Male_90_AD8B4EE143AD76E10D4B8688D876BC5D", "Night Spear Male"},
            {"LongcoatB_Male_91_E0EDF82041AF292E1023F1877D45BFFD", "Raven Fatigues Male"},
            {"LongcoatD_Male_92_1FCB70FD4263437181A3819047163B08", "Winter Mantle Male"},
            {"LongcoatE_Male_93_84F3489247101AB32BA7ECBE5B101D04", "Silver Garb Male"},
            {"LongcoatH_Male_94_6767DE5A400777425E35768A854709A3", "Queenslayer Thorn Male"},
            {"LongcoatI_Male_208_4A8DEE0F48763BBCE94124BD3DDAE327", "Festive Spear Male"},
            {"MufflerA_Male_95_EE91F3F640874D8C89C5569042488511", "Night Thorn Male"},
            {"MufflerC_Male_96_4644BC864CEAC1D34373119603E7AEE2", "Ivory Grace Male"},
            {"MufflerD_Male_97_C16F0FD24FA79FE096041CA10EC219AB", "GXH Assault Male"},
            {"MufflerE_Male_98_0DB76CF842A18DB8F548B0BF463C7931", "Prayer Shawl Male"},
            {"MufflerF_Male_99_1BB5705C44080AA794E4F7B6BB10F7C4", "Suicide Spur Male"},
            {"MufflerG_Male_209_40856F7648146D3A8EE53B839D98106D", "Festive Thorn Male"},
            {"DrapeA_Female_160_C4D666BD45DB647455B420970FF43618", "Night Fang Female"},
            {"DrapeB_Female_161_DEB0E0DF46EFFA5EA5200888A82C4A6A", "Blue Hounds Female"},
            {"DrapeC_Female_162_05BF3D6C4E2B5CB5916D68AE93126204", "GXL Defender Female"},
            {"DrapeD_Female_163_7B85C93B41FB4DE0C0A996A4AD71B321", "Hedgehog Fort Female"},
            {"DrapeE_Female_164_D13646234DDBC40137E6CC8627C0EA01", "White Vestment Female"},
            {"DrapeF_Female_210_2C5FF0FF45239FC90B84A48ADEF202CB", "Hedgehog Fort Female"},
            {"GauntletA_Female_165_FE229D8641EB7EEA12D19884E6E9C56E", "Night Claw Female"},
            {"GauntletC_Female_166_FFD837B5438C841AFD8237AE395E3E33", "Noble Silver Female"},
            {"GauntletE_Female_167_EAAE751C4BC90F46A2D890B9943911AD", "GXM Variant Female"},
            {"GauntletF_Female_168_AF89B0324D493CF45894CC93AC8B0F04", "Blackblood Liberator Female"},
            {"GauntletH_Female_169_12FB5C0D44668FB3E9432099DB90AD6E", "Queenslayer Claw Female"},
            {"GauntletI_Female_185_A9DC00FA4B1FFB7D6BCA43A7F85FB713", "Venous Claw Female"},
            {"GauntletJ_Female_211_B8D39F8748C0B301DD0B57973E33D2C4", "Festive Claw Female"},
            {"LongcoatA_Female_170_BCFA903D47C333784F8DE5800A555FF8", "Night Spear Female"},
            {"LongcoatB_Female_171_F79C617349924A761B3E618FDF95417A", "Raven Fatigues Female"},
            {"LongcoatD_Female_172_27BD97FD4F9F6AB064D32E8633714C7B", "Winter Mantle Female"},
            {"LongcoatE_Female_173_0B77B8DE4F280DDFEF75F3966A8F4988", "Silver Garb Female"},
            {"LongcoatH_Female_174_728C335949BF376E01FAEFB3972646A6", "Queenslayer Thorn Female"},
            {"LongcoatI_Female_212_3B5566804AADE01FDFB6FAA07D3BFDC3", "Festive Spear Female"},
            {"MufflerA_Female_175_7EBDD4574BEF5E978F839E8CD8DC0825", "Night Thorn Female"},
            {"MufflerC_Female_176_4FD06BB045973199868B9CA28340EDFF", "Ivory Grace Female"},
            {"MufflerD_Female_177_EC0ECACE4EE72CFB07FF22BA0E3CDAE4", "GXH Assault Female"},
            {"MufflerE_Female_178_E74137E84026A622F1B8629E81BD3B89", "Prayer Shawl Female"},
            {"MufflerF_Female_179_8A85B6264B5DC00F7D7E0183109598BF", "Suicide Spur Female"},
            {"MufflerG_Female_213_847BA24A4937103F37A24A80BB67E6CC", "Festive Thorn Female"},
            {"GauntletInvisible_189_B9F4FEB24A890275F93457AC7E2724F4", "GauntletInvisible"},
        };

        public StructPropertyData Make()
        {
            StructPropertyData data = new StructPropertyData();
            data.Name = new FName(Name);
            data.StructType = new FName(StructType);
            data.Value = new List<PropertyData>();
            data.Value.Add(new SoftObjectPropertyData() { Name = new FName(NameToKey["InnerKey"]), Value = new FName(InnerKey) });
            foreach (var outer in InnerPartsVisibilityList)
            {
                data.Value.Add(outer.Make());
            }
            return data;
        }

        public void Read(StructPropertyData data)
        {
            Name = data.Name.Value.Value;
            InnerKey = ((SoftObjectPropertyData)data.Value[0]).Value.Value.Value;
            for (int i = 1; i < data.Value.Count; i++)
            {
                var outer = new InnerPartsVisibility();
                outer.Read((StructPropertyData)data.Value[i]);
                InnerPartsVisibilityList.Add(outer);
            }
        }

        public bool Equals(PartsVisibilityByOuter parts)
        {
            bool result = true;
            for (int i = 0; i < InnerPartsVisibilityList.Count; i++)
            {
                if (!InnerPartsVisibilityList[i].Equals(parts.InnerPartsVisibilityList[i]))
                {
                    result = false;
                    break;
                }
            }
            return Name == parts.Name && InnerKey == parts.InnerKey && result == true;
        }
    }
}
