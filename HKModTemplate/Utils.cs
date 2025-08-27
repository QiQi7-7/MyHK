using System.Reflection;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;

namespace MyHK
{
    internal static class Utils
    {
        public static string ReadEmbeddedResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using Stream stream = assembly.GetManifestResourceStream(resourceName)
                ?? throw new InvalidOperationException($"资源 {resourceName} 未找到。");
            using StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static FieldInfo GetPrivateField(object _class , string _name)
        {
            return _class.GetType().GetField(_name, BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public static FaceObject CopyFaceObject(FaceObject targetAction)
        {
            FaceObject result = new FaceObject
            {
                objectA = targetAction.objectA,
                objectB = targetAction.objectB,
                spriteFacesRight = targetAction.spriteFacesRight,
                playNewAnimation = targetAction.playNewAnimation,
                newAnimationClip = targetAction.newAnimationClip,
                resetFrame = targetAction.resetFrame,
                everyFrame = targetAction.everyFrame,
            };
            return result;
        }

        public static FloatCompare CopyFloatCompare(FloatCompare targetAction)
        {
            FloatCompare result = new FloatCompare
            {
                float1 = targetAction.float1,
                float2 = targetAction.float2,
                tolerance = targetAction.tolerance,
                equal = targetAction.equal,
                lessThan = targetAction.lessThan,
                greaterThan = targetAction.greaterThan,
                everyFrame = targetAction.everyFrame
            };
            return result;
        }

        public static GetPosition CopyGetPosition(GetPosition targetAction)
        {
            GetPosition result = new GetPosition
            {
                gameObject = targetAction.gameObject,
                vector = targetAction.vector,
                x = targetAction.x,
                y = targetAction.y,
                z = targetAction.z,
                space = targetAction.space,
                everyFrame = targetAction.everyFrame
            };
            return result;
        }

        public static SendEventByName CopySendEventByName(SendEventByName targetAction)
        {
            SendEventByName result = new SendEventByName
            {
                eventTarget = targetAction.eventTarget,
                sendEvent = targetAction.sendEvent,
                delay = targetAction.delay,
                everyFrame = targetAction.everyFrame
            };
            return result;
        }

        public static AudioPlayerOneShot CopyAudioPlayerOneShot(AudioPlayerOneShot targetAction)
        {
            AudioPlayerOneShot result = new AudioPlayerOneShot
            {
                audioPlayer = targetAction.audioPlayer,
                spawnPoint = targetAction.spawnPoint,
                audioClips = targetAction.audioClips,
                weights = targetAction.weights,
                pitchMax = targetAction.pitchMax,
                pitchMin = targetAction.pitchMin,
                volume = targetAction.volume,
                delay = targetAction.delay,
                storePlayer = targetAction.storePlayer,
            };
            return result;
        }
    }
}
