using System;
using SC3_Alarm_Module.CBL;
using SC3_Alarm_Module.Entity;
using SC3_Alarm_Module.Collection;
using SC3_Alarm_Module.DAL;


namespace SC3_Alarm_Module.SBL
{
    public class LayersSBL
    {
        CHK Chk = new CHK();
        LayersDAL LayersDAL_Obj = new LayersDAL();

        public bool Layers_Delete(string username, string password, int layer_id)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return LayersDAL_Obj.Layers_Delete(username, password, layer_id);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Layers Layers_Insert(string username, string password, Layers Layer)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return LayersDAL_Obj.Layers_Insert(username, password, Layer);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public LayersCollection Layers_Select(string username, string password, int layerid)
        {
            try
            {

                if (Chk.check_authority(username, password))
                {
                    return LayersDAL_Obj.Layers_Select(username, password, layerid);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public LayersCollection Layers_SelectByUserId(string username, string password, int userid)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return LayersDAL_Obj.Layers_SelectByUserId(username, password, userid);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Layers_Update(string username, string password, Layers layer_obj)
        {
            try
            {
                if (Chk.check_authority(username, password))
                {
                    return LayersDAL_Obj.Layers_Update(username, password, layer_obj);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}