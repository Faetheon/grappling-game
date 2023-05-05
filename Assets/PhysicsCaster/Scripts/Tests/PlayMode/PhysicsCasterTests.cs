using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using PhysicsCasterRuntime;

public class PhysicsCasterTests
{
    PhysicsCaster _caster;

    [UnityTest]
    public IEnumerator TestRaySpaceSetter()
    {
        Space space = Space.World;
        GivenPhysicsCaster();
        WhenRaySpaceIsSet(space);
        ThenRaySpaceShouldBe(space);
        yield return null;
    }
    [UnityTest]
    public IEnumerator TestRaySetter()
    {
        Ray ray = new Ray(Vector3.down, Vector3.up);
        GivenPhysicsCaster();
        WhenRayIsSet(ray);
        ThenRayShouldBe(ray);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestMaxDistanceSetter()
    {
        float maxDistance = 10;
        GivenPhysicsCaster();
        WhenMaxDistanceIsSet(maxDistance);
        ThenMaxDistanceShouldBe(maxDistance);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestLayerMaskSetter()
    {
        LayerMask mask = 0;
        GivenPhysicsCaster();
        WhenLayerMaskIsSet(mask);
        ThenLayerMaskShouldBe(mask);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestQueryTriggerInteractionSetter()
    {
        QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Collide;
        GivenPhysicsCaster();
        WhenQueryTriggerInteractionIsSet(queryTriggerInteraction);
        ThenQueryTriggerInteractionShouldBe(queryTriggerInteraction);
        yield return null;
    }

    private void GivenPhysicsCaster()
    {
        GameObject container = new GameObject("Physics Caster");
        _caster = container.AddComponent<PhysicsCaster>();
    }

    private void WhenRaySpaceIsSet(Space space)
    {
        _caster.RaySpace = space;
    }
    private void ThenRaySpaceShouldBe(Space space)
    {
        Assert.AreEqual(_caster.RaySpace, space);
    }

    private void WhenRayIsSet(Ray ray)
    {
        _caster.Ray = ray;
    }
    private void ThenRayShouldBe(Ray ray)
    {
        Assert.AreEqual(_caster.Ray, ray);
    }

    private void WhenMaxDistanceIsSet(float maxDistance)
    {
        _caster.MaxDistance = maxDistance;
    }
    private void ThenMaxDistanceShouldBe(float maxDistance)
    {
        Assert.AreEqual(_caster.MaxDistance, maxDistance);
    }

    private void WhenLayerMaskIsSet(LayerMask layerMask)
    {
        _caster.LayerMask = layerMask;
    }
    private void ThenLayerMaskShouldBe(LayerMask layerMask)
    {
        Assert.AreEqual(_caster.LayerMask, layerMask);
    }

    private void WhenQueryTriggerInteractionIsSet(QueryTriggerInteraction queryTriggerInteraction)
    {
        _caster.QueryTriggerInteraction = queryTriggerInteraction;
    }
    private void ThenQueryTriggerInteractionShouldBe(QueryTriggerInteraction queryTriggerInteraction)
    {
        Assert.AreEqual(_caster.QueryTriggerInteraction, queryTriggerInteraction);
    }
}
