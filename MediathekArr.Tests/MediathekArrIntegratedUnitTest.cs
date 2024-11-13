using MediathekArr.Tests.Fixtures;

namespace MediathekArr.Tests;

public abstract class MediathekArrIntegratedUnitTest(MediathekArrWebApplicationFactory factory) : AbstractIntegratedUnitTest<MediathekArrWebApplicationFactory, Program>(factory);